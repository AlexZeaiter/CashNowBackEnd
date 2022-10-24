using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CashNow.Models
{
    public class APRequestDetails
    {
        [JsonProperty("ap_request_details_id")]
        public int APRequestDetailsId { get; set; }

        [JsonProperty("ap_request_id")]
        public int APRequestId { get; set; }

        [JsonProperty("ap_request_status")]
        public string APRequestStatus { get; set; }

        [JsonProperty("ap_settelment_date")]
        public DateTime APSettelmentDate { get; set; }

        [JsonProperty("mediation_fees")]
        public float MediationFees { get; set; }

        [JsonProperty("sourcing_fees")]
        public float SourcingFees { get; set; }

        [JsonProperty("settlement_value")]
        public float SettlementValue { get; set; }

        [JsonProperty("chosen_payment_option")]
        public int ChosenPaymentOption { get; set; }
    }
}
