using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CashNow.Models.RequestModels
{
    public class RegistrationRequestModel
    {
        [JsonProperty("companyUserName")]
        public string CompanyUserName { get; set; }
        [JsonProperty("companyPassword")]
        public string CompanyPassword { get; set; }
        [JsonProperty("companyEmailAddress")]
        public string CompanyEmailAddress { get; set; }
        [JsonProperty("companyName")]
        public string CompanyName { get; set; }
        [JsonProperty("companyType")]
        public string CompanyType { get; set; }
        [JsonProperty("yearOfEstablishment")]
        public DateTime YearOfEstablishment { get; set; }
        [JsonProperty("companySize")]
        public int CompanySize { get; set; }
        [JsonProperty("companyAddress")]
        public string CompanyAddress { get; set; }
        [JsonProperty("companyRepContactName")]
        public string CompanyRepContactName { get; set; }
        [JsonProperty("companyRepPhoneNumber")]
        public int CompanyRepPhoneNumber { get; set; }
        [JsonProperty("companyRepEmailAddress")]
        public string CompanyRepEmailAddress { get; set; }
        [JsonProperty("interestedIn")]
        public string InterestedIn { get; set; }
        [JsonProperty("isApproved")]
        public bool IsApproved { get; set; }
    }
}
