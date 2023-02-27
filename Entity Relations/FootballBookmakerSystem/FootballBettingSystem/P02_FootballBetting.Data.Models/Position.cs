using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using P02_FootballBetting.Data.Common;

namespace P02_FootballBetting.Data.Models
{
    public class Position
    {
        public Position()
        {
            this.Players = new HashSet<Player>();
        }
        [Key]
        public int PositionId { get; set; }

        [Required]
        [MaxLength(GlobalConstants.PositionNameMaxLength)]
        public string PositionName { get; set; }

        public virtual ICollection<Player> Players { get; set; }
    }
}
