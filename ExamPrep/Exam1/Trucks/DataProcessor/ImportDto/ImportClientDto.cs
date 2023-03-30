using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Trucks.Common;
using Trucks.Data.Models;

namespace Trucks.DataProcessor.ImportDto
{
    public class ImportClientDto
    {
        [Required]
        [JsonProperty("Name")]
        [MinLength(ValidationConstatnts.ClientNameMinLength)]
        [MaxLength(ValidationConstatnts.ClientNameMaxLength)]
        public string Name { get; set; } = null!;

        [JsonProperty("Nationality")]
        [Required]
        [MinLength(ValidationConstatnts.ClientNationalityMinLength)]
        [MaxLength(ValidationConstatnts.ClientNationalityMaxLength)]
        public string Nationality { get; set; } = null!;

        [JsonProperty("Type")]
        public string Type { get; set; } = null!;

        [JsonProperty("Trucks")]
        public int[] TrucksIds { get; set; }
    }
}
