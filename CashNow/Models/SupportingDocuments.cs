using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CashNow.Models
{
    public class SupportingDocuments
    {
        [JsonProperty("supporting_documents_id")]
        public int SupportingDocumentsId { get; set; }

        [JsonProperty("ap_request_id")]
        public int APRequestId { get; set; }

        [JsonProperty("po_file_Data")]
        [MaxLength]
        public byte[] POFileData { get; set; }

        [JsonProperty("po_file_name")]
        public string POFileName { get; set; }

        [JsonProperty("po_file_type")]
        public string POFileType { get; set; }

        [JsonProperty("invoice_file_data")]
        [MaxLength]
        public byte[] InvoiceFileData { get; set; }

        [JsonProperty("invoice_file_name")]
        public string InvoiceFileName { get; set; }

        [JsonProperty("invoice_file_type")]
        public string InvoiceFileType { get; set; }

        [JsonProperty("email_confirmation_file_data")]
        [MaxLength]
        public byte[] EmailConfirmationFileData { get; set; }

        [JsonProperty("email_confirmation_file_name")]
        public string EmailConfirmationFileName { get; set; }

        [JsonProperty("email_confirmation_file_type")]
        public string EmailConfirmationFileType { get; set; }
    }
}
