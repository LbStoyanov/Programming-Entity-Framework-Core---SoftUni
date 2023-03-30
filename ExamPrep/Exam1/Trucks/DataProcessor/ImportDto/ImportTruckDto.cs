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
        [RegularExpression(ValidationConstatnts.TruckRegistrationNumberRegex)]
        public string? RegistrationNumber { get; set; }

        [XmlElement("VinNumber")]
        [Required]
        [MinLength(ValidationConstatnts.VinNumberLength)]
        [MaxLength(ValidationConstatnts.VinNumberLength)]
        public string VinNumber { get; set; } = null!;

        
        [XmlElement("TankCapacity")]
        [Range(ValidationConstatnts.TankCapacityMin,ValidationConstatnts.TankCapacityMax)]
        public int TankCapacity { get; set; }

        [XmlElement("CargoCapacity")]
        [Range(ValidationConstatnts.CargoCapacityMin, ValidationConstatnts.CargoCapacityMax)]
        public int CargoCapacity { get; set;}

        [XmlElement("CategoryType")]
        [Range(ValidationConstatnts.CategoryTypeMin, ValidationConstatnts.CategoryTypeMax)]
        public int CategoryType { get; set;}

        [XmlElement("MakeType")]
        [Range(ValidationConstatnts.MakeTypeMin, ValidationConstatnts.MakeTypeMax)]
        public int MakeType { get; set;}


    }
}
