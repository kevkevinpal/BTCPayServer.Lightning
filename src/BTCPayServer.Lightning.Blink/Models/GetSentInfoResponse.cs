using System;
using BTCPayServer.Lightning.Blink.JsonConverters;
using BTCPayServer.Lightning.JsonConverters;
using Newtonsoft.Json;

namespace BTCPayServer.Lightning.Blink.Models
{
    public class GetSentInfoResponse
    {
        public Guid Id { get; set; }
        public Guid ParentId { get; set; }

        public string PaymentHash { get; set; }
        public string PaymentType { get; set; }
        public string RecipientNodeId { get; set; }
        public long AmountMsat { get; set; }
        [JsonConverter(typeof(BlinkDateTimeJsonConverter))]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonConverter(typeof(LightMoneyJsonConverter))]
        public LightMoney RecipientAmount { get; set; }

        [JsonConverter(typeof(LightMoneyJsonConverter))]
        public LightMoney Amount { get; set; }

        public PaymentStatus Status { get; set; }
    }
}
