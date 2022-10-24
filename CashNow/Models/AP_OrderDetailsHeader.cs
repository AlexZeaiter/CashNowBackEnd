using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CashNow.Models
{
    public class AP_OrderDetailsHeader
    {
        [JsonProperty("ap_order_details_header_id")]
        public int AP_OrderDetailsHeaderId { get; set; }

        [JsonProperty("ap_request_id")]
        public int APRequestId { get; set; }

        [JsonProperty("delivery_due_date")]
        public DateTime? DeliveryDueDate { get; set; }

        [JsonProperty("po_id")]
        public string PO_Id { get; set; }

        [JsonProperty("project_instructions")]
        public string ProjectInstructions { get; set; }

        [JsonProperty("project_implementation_duration")]
        public string ProjectImplementationDuration { get; set; }

        [JsonProperty("project_site_address")]
        public string ProjectSiteAddress { get; set; }

        [JsonProperty("warranty_included")]
        public bool WarrantyIncluded { get; set; }

        [JsonProperty("warranty_duration")]
        public string WarrantyDuration { get; set; }

        [JsonProperty("quality_certifications")]
        public string QualityCertifications { get; set; }

        [JsonProperty("safety_requirements")]
        public string SafetyRequirements { get; set; }

        [JsonProperty("other_conditions")]
        public string OtherConditions { get; set; }

        [JsonProperty("product_specification_documents")]
        public byte[] ProductSpecificationDocuments { get; set; }

        [JsonProperty("other_documents")]
        public byte[] OtherDocuments { get; set; }
    }
}
