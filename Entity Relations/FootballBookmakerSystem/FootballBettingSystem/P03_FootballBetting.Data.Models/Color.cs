using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using System.Text;
using P03_FootballBetting.Data.Common;

namespace P03_FootballBetting.Data.Models
{
    public class Color
    {
        [Key]
        public int ColorId { get; set; }

        [Required]
        [MaxLength(GlobalConstants.ColorNameMaxLength)]
        public string Name { get; set; }
        
    }
}
