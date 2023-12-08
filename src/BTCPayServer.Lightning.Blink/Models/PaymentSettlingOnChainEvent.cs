namespace BTCPayServer.Lightning.Blink.Models
{
    public partial class PaymentSettlingOnChainEvent
    {
        public string Type { get; set; }
        public long Amount { get; set; }
        public string PaymentHash { get; set; }
        public long Timestamp { get; set; }
    }
}
