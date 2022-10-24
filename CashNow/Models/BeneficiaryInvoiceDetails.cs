using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CashNow.Models
{
    public class BeneficiaryInvoiceDetails
    {
        [JsonProperty("beneficiary_invoice_details_id")]
        public int BeneficiaryInvoiceDetailsId { get; set; }

        [JsonProperty("ap_request_id")]
        public int APRequestId { get; set; }

        [JsonProperty("customer_invoice_number")]
        public string CustomerInvoiceNumber { get; set; }

        [JsonProperty("total_invoice_value")]
        public float TotalInvoiceValue { get; set; }

        [JsonProperty("total_invoice_value_includes_vat")]
        public bool TotalInvoiceValueIncludesVAT { get; set; }

        [JsonProperty("pay_to_beneficiary_due_date")]
        public DateTime PayToBeneficiaryDueDate { get; set; }

        [JsonProperty("total_value_to_be_paid_to_beneficiary")]
        public float TotalValueToBePaidToBeneficiary { get; set; }
    }
}
