using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CashNow.Models
{
    public class AP_OrderDetailsItems
    {
        [Key]
        [JsonProperty("ap_order_details_item_id")]
        public int AP_OrderDetailsItemId { get; set; }

        [JsonProperty("ap_order_details_header_id")]
        public int AP_OrderDetailsHeaderId { get; set; }

        [JsonProperty("item_name")]
        public string ItemName { get; set; }

        [JsonProperty("item_part_number")]
        public string ItemPartNumber { get; set; }

        [JsonProperty("item_description")]
        public string ItemDescription { get; set; }

        [JsonProperty("unit_of_measurement")]
        public string UnitOfMeasurement { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("commodity_type")]
        public string CommodityType { get; set; }

        [JsonProperty("item_specs")]
        public string ItemSpecs { get; set; }

        [JsonProperty("preferred_brand")]
        public string PreferredBrand { get; set; }

        [JsonProperty("preferred_country_of_origin")]
        public string PreferredCountryOfOrigin { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }
    }
}
