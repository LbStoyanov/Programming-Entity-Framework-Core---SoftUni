using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Trucks.Common;

namespace Trucks.DataProcessor.ImportDto
{
    [XmlType("Truck")]
    public class ImportTruckDto
    {
        [XmlElement("RegistrationNumber")]
        [MinLength(ValidationConstatnts.RegistrationNumberLength)]
        [MaxLength(ValidationConstatnts.RegistrationNumberLength)]
        public string? RegistrationNumber { get; set; }

        [XmlElement("VinNumber")]
        public string VinNumber { get; set; } = null!;

        [XmlElement("TankCapacity")]
        public int TankCapacity { get; set; }

        [XmlElement("CargoCapacity")]
        public int CargoCapacity { get; set;}

        [XmlElement("CategoryType")]
        public int CategoryType { get; set;}

        [XmlElement("MakeType")]
        public int MakeType { get; set;}


    }
}
