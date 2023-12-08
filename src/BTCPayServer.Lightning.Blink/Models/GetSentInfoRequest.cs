namespace BTCPayServer.Lightning.Blink.Models
{
    public class GetSentInfoRequest
    {
        public string PaymentHash { get; set; }
        public string Id { get; set; }
    }
}
