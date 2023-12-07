using System;
using System.Net.Http;
using NBitcoin;

namespace BTCPayServer.Lightning.Blink;

public class BlinkConnectionStringHandler : ILightningConnectionStringHandler
{
    private readonly HttpClient _httpClient;

    public BlinkConnectionStringHandler(HttpClient  httpClient = null)
    {
        _httpClient = httpClient;
    }
    public ILightningClient Create(string connectionString, Network network, out string error)
    {
        var kv = LightningConnectionStringHelper.ExtractValues(connectionString, out var type);
        if (type != "blink")
        {
            error = null;
            return null;
        }
        
        if (!kv.TryGetValue("server", out var server))
        {
            error = $"The key 'server' is mandatory for blink connection strings";
            return null;
        }
        
        if (!Uri.TryCreate(server, UriKind.Absolute, out var blinkuri)
            || (blinkuri.Scheme != "http" && blinkuri.Scheme != "https"))
        {
            error = $"The key 'server' should be an URI starting by http:// or https://";
            return null;
        }

        kv.TryGetValue("username", out var username);
        kv.TryGetValue("password", out var password);
        if (kv.TryGetValue("bitcoin-host", out var bitcoinHost))
        {
            if (!kv.TryGetValue("bitcoin-auth", out var bitcoinAuth))
            {
                
                error =
                    $"The key 'bitcoin-auth' is mandatory for blink connection strings when bitcoin-host is specified";
                return null;
            }
        }

        error = null;
        return new BlinkLightningClient(blinkuri,  username, password, network, _httpClient);
    }
}
