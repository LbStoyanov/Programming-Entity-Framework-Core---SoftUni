using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using P03_FootballBetting.Data.Common;

namespace P03_FootballBetting.Data.Models
{
    public class Position
    {
        [Key]
        public int PostionId { get; set; }

        [Required]
        [MaxLength(GlobalConstants.PositionNameMaxLength)]
        public string PostionName { get; set; }
    }
}
