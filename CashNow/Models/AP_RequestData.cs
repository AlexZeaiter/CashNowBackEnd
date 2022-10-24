using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CashNow.Models
{
    public class AP_RequestData
    {
        [JsonProperty("account_payables_request")]
        public AccountPayablesRequests AccountPayablesRequest { get; set; }

        [JsonProperty("ap_order_details_header")]
        public AP_OrderDetailsHeader AP_OrderDetailsHeader { get; set; }

        [JsonProperty("ap_order_details_items_list")]
        public List<AP_OrderDetailsItems> AP_OrderDetailsItemsList { get; set; }

        [JsonProperty("ap_request_details")]
        public APRequestDetails APRequestDetails { get; set; }

        [JsonProperty("beneficiary_details")]
        public BeneficiaryDetails BeneficiaryDetails { get; set; }

        [JsonProperty("beneficiary_invoice_details")]
        public BeneficiaryInvoiceDetails BeneficiaryInvoiceDetails { get; set; }

        [JsonProperty("supporting_documents")]
        public SupportingDocuments SupportingDocuments { get; set; }
    }
}
