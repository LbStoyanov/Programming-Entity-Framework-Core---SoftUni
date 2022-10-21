using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using P03_FootballBetting.Data.Common;

namespace P03_FootballBetting.Data.Models
{
    public class Position
    {
        public Position()
        {
            this.Players = new HashSet<Player>();
        }
        [Key]
        public int PostionId { get; set; }

        [Required]
        [MaxLength(GlobalConstants.PositionNameMaxLength)]
        public string PostionName { get; set; }

        public virtual ICollection<Player> Players { get; set; }
    }
}
