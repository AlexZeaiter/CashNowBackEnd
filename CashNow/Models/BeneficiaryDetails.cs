using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CashNow.Models
{
    public class BeneficiaryDetails
    {
        [JsonProperty("beneficiary_details_id")]
        public int BeneficiaryDetailsId { get; set; }

        [JsonProperty("ap_request_id")]
        public int APRequestId { get; set; }

        [JsonProperty("is_ots")]
        public bool IsOTS { get; set; }

        [JsonProperty("beneficiary_name")]
        public string BeneficiaryName { get; set; }

        [JsonProperty("beneficiary_address")]
        public string BeneficiaryAddress { get; set; }

        [JsonProperty("beneficiary_tax_id")]
        public string BeneficiaryTaxId { get; set; }

        [JsonProperty("beneficiary_commercial_register")]
        public int BeneficiaryCommercialRegister { get; set; }

        [JsonProperty("beneficiary_contact_name")]
        public string BeneficiaryContactName { get; set; }

        [JsonProperty("beneficiary_contact_number")]
        public string BeneficiaryContactNumber { get; set; }

        [JsonProperty("beneficiary_contact_email")]
        public string BeneficiaryContactEmail { get; set; }

        [JsonProperty("beneficiary_bank")]
        public int? BeneficiaryBank { get; set; }

        [JsonProperty("beneficiary_bank_iban")]
        public string BeneficiaryBankiBAN { get; set; }
    }
}
