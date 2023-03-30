using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Trucks.Data.Models;

namespace Trucks.DataProcessor.ImportDto
{
    public class ImportClientDto
    {
        [JsonProperty("Name")]
        public string Name { get; set; } = null!;

        [JsonProperty("Nationality")]
        public string Nationality { get; set; } = null!;

        [JsonProperty("Type")]
        public string Type { get; set; } = null!;

        [JsonProperty("ClientsTrucks")]
        public ICollection<ClientTruck> ClientsTrucks { get; set; }
    }
}
