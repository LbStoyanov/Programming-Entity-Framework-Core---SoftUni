
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using P03_FootballBetting.Data.Common;

namespace P03_FootballBetting.Data.Models
{
    public class Town
    {
        public Town()
        {
            this.Teams = new HashSet<Team>();
        }
        [Key]
        public int TownId { get; set; }
        
        [Required]
        [MaxLength(GlobalConstants.TownNameMaxLength)]
        public string Name { get; set; }


        public int CountryId { get; set; }

        public virtual ICollection<Team> Teams { get; set; }

        public virtual Country Country { get; set; }
    }
}
