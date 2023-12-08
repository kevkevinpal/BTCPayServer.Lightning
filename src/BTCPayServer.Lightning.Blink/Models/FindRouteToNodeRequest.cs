namespace BTCPayServer.Lightning.Blink.Models
{
    public class FindRouteToNodeRequest
    {
        public string NodeId { get; set; }
        public int AmountMsat { get; set; }
    }
}
