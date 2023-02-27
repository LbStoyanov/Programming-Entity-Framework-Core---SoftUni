
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using P02_FootballBetting.Data.Common;

namespace P02_FootballBetting.Data.Models
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

        [ForeignKey(nameof(Country))]
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }

        public virtual ICollection<Team> Teams { get; set; }

       
    }
}
