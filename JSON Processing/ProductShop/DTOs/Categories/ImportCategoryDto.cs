using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductShop.DTOs.Categories
{
    [JsonObject]
    public class ImportCategoryDto
    {
        [JsonProperty("name")]
        
        public string Name { get; set; }
    }
}
