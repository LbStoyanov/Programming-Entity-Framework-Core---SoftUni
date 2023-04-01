using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Boardgames.DataProcessor.ImportDto
{
    [XmlType("Creator")]
    public class ImportCreatorDto
    {
        [XmlElement("FirstName")]
        [Required]
        [MinLength(2)]
        [MaxLength(7)]
        public string FirstName { get; set; } = null!;

        [XmlElement("LastName")]
        [MinLength(2)]
        [MaxLength(7)]
        [Required]
        public string LastName { get; set; } = null!;

        [XmlArray("Boardgames")]
        [Required]
        public ImportBoardgameDto[] Boardgames { get; set; }
    }
}
