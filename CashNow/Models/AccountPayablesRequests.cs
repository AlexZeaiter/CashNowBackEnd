using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CashNow.Models
{
    public class AccountPayablesRequests
    {
        [Key]
        [JsonProperty("ap_request_id")]
        public int APRequestId { get; set; }

        [JsonProperty("company_id")]
        public Guid CompanyId { get; set; }

        [JsonProperty("beneficiary_details_id")]
        public int BeneficiaryDetailsId { get; set; }

        [JsonProperty("beneficiary_invoice_details_id")]
        public int BeneficiaryInvoiceDetailsId { get; set; }

        [JsonProperty("supporting_documents_id")]
        public int SupportingDocumentsId { get; set; }

        [JsonProperty("ap_order_details_header_id")]
        public int AP_OrderDetailsHeaderId { get; set; }

        [JsonProperty("ap_request_details_id")]
        public int APRequestDetailsId { get; set; }
    }
}
