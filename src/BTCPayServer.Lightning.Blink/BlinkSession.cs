using System;
using System.Net.Http.Headers;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BTCPayServer.Lightning.Blink.Models;
using Newtonsoft.Json.Linq;

namespace BTCPayServer.Lightning.Blink
{
    public class BlinkSession : WebsocketListener, ILightningInvoiceListener
    {
        private readonly BlinkLightningClient lightningClient;

        public BlinkSession(ClientWebSocket clientWebSocket, BlinkLightningClient lightningClient) : base(clientWebSocket)
        {
            this.lightningClient = lightningClient;
        }

        public async Task<LightningInvoice> WaitInvoice(CancellationToken cancellation)
        {
retry:
            var message = await this.WaitMessage(cancellation);
            var obj = JObject.Parse(message);
            object typedObj = null;
            switch (obj.GetValue("type").ToString())
            {
                //case "payment-relayed":
                //    typedObj = obj.ToObject<PaymentRelayedEvent>();
                //    break;
                case "payment-received":
                    typedObj = obj.ToObject<PaymentReceivedEvent>();
                    break;
                    //case "payment-failed":
                    //    typedObj = obj.ToObject<PaymentFailedEvent>();
                    //    break;
                    //case "payment-sent":
                    //    typedObj = obj.ToObject<PaymentSentEvent>();
                    //    break;
                    //case "payment-settling-onchain":
                    //    typedObj = obj.ToObject<PaymentSettlingOnChainEvent>();
                    //    break;
            }

            if (typedObj is PaymentReceivedEvent r)
            {
                return await lightningClient.GetInvoice(r.PaymentHash);
            }
            goto retry;
        }
    }
}
