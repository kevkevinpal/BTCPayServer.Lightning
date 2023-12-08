namespace BTCPayServer.Lightning.Blink.Models
{
    public class ForceCloseRequest
    {
        public string ChannelId { get; set; }
        public string ShortChannelId { get; set; }
    }
}
