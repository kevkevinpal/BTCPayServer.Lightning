namespace BTCPayServer.Lightning.Blink.Models
{
    public class GetReceivedInfoRequest
    {
        public string PaymentHash { get; set; }
        public string Invoice { get; set; }
    }
}
