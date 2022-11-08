using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductShop.DTOs.Product
{
    [JsonObject]
    public class ExportUserSoldProductsDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("byuerFirstName")]
        public string ByuerFirstName { get; set; }

        [JsonProperty("byuerLastName")]
        public string ByuerLastName { get; set; }
    }
}
