using System;
using Newtonsoft.Json;

namespace BTCPayServer.Lightning.Blink.Models
{
    public partial class PaymentReceivedEvent
    {
        public string Type { get; set; }
        public long Amount { get; set; }
        public string PaymentHash { get; set; }
        public string FromChannelId { get; set; }
        public long Timestamp { get; set; }
    }
}
