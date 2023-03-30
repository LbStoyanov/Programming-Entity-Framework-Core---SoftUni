﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Trucks.Common;

namespace Trucks.DataProcessor.ImportDto
{
    [XmlType("Despatcher")]
    public class ImportDespatcherDto
    {
        [XmlElement("Name")]
        [Required]
        [MinLength(ValidationConstatnts.DespatcherNameMinLength)]
        [MaxLength(ValidationConstatnts.DespatcherNameMaxLength)]
        public string Name { get; set; } = null!;

        [XmlElement("Position")]
        [Required]
        public string Position { get; set; } = null!;

        [XmlArray("Trucks")]
        public ImportTruckDto[] Trucks { get; set; }
    }
}
