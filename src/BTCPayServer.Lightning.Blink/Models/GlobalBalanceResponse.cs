using BTCPayServer.Lightning.Blink.JsonConverters;
using BTCPayServer.Lightning.JsonConverters;
using NBitcoin;
using Newtonsoft.Json;

namespace BTCPayServer.Lightning.Blink.Models
{
    public class GlobalBalanceResponse
    {
        [JsonProperty("total")]
        public decimal Total { get; set; }

        [JsonProperty("onChain")]
        public GlobalOnchainBalance Onchain { get; set; }

        [JsonProperty("offChain")]
        public GlobalOffchainBalance Offchain { get; set; }
    }

    public class GlobalOnchainBalance
    {
        [JsonProperty("confirmed")]
        public decimal Confirmed { get; set; }
        
        [JsonProperty("unconfirmed")]
        public decimal Unconfirmed { get; set; }
    }

    public class GlobalOffchainBalance
    {
        [JsonProperty("waitForFundingConfirmed")]
        [JsonConverter(typeof(BlinkBtcJsonConverter))]
        public LightMoney WaitForFundingConfirmed { get; set; }
        
        [JsonProperty("waitForChannelReady")]
        [JsonConverter(typeof(BlinkBtcJsonConverter))]
        public LightMoney WaitForChannelReady { get; set; }
        
        [JsonProperty("waitForPublishFutureCommitment")]
        [JsonConverter(typeof(BlinkBtcJsonConverter))]
        public LightMoney WaitForPublishFutureCommitment { get; set; }
        
        [JsonProperty("negotiating")]
        [JsonConverter(typeof(BlinkBtcJsonConverter))]
        public LightMoney Negotiating { get; set; }
        
        [JsonProperty("normal")]
        public BlinkChannelBalance Normal { get; set; }
        
        [JsonProperty("shutdown")]
        public BlinkChannelBalance Shutdown { get; set; }
        
        [JsonProperty("closing")]
        public BlinkClosingBalances Closing { get; set; }
    }

    public class BlinkClosingBalances
    {
        
        [JsonProperty("localCloseBalance")]
        public BlinkChannelBalance LocalCloseBalance { get; set; }
        
        [JsonProperty("remoteCloseBalance")]
        public BlinkChannelBalance RemoteCloseBalance { get; set; }
        
        [JsonProperty("mutualCloseBalance")]
        public BlinkChannelBalance MutualCloseBalance { get; set; }
        
        [JsonProperty("unknownCloseBalance")]
        public BlinkChannelBalance UnknownCloseBalance { get; set; }
    }

    public class BlinkChannelBalance
    {
        [JsonProperty("toLocal")]
        [JsonConverter(typeof(BlinkBtcJsonConverter))]
        public LightMoney ToLocal { get; set; }
    }
}
