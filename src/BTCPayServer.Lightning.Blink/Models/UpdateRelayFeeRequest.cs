namespace BTCPayServer.Lightning.Blink.Models
{
    public class UpdateRelayFeeRequest
    {
        public string ChannelId { get; set; }
        public int FeeBaseMsat { get; set; }
        public int FeeProportionalMillionths { get; set; }

    }
}
