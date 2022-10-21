using System;
using System.ComponentModel.DataAnnotations;
using P03_FootballBetting.Data.Common;

namespace P03_FootballBetting.Data.Models
{
    public class Team
    {
        [Key]
        public int TeamId { get; set; }

        [Required]
        [MaxLength(GlobalConstants.TeamNameMaxLength)]
        public string Name { get; set; }

        [MaxLength(GlobalConstants.TeamLogoUrlMaxLength)]
        public string LogoUrl { get; set; }

        [Required]
        [MaxLength(GlobalConstants.TeamInitialsMaxLength)]
        public string Initials { get; set; }


        public decimal Budget { get; set; }

        public int PrimaryKitColorId { get; set; }

        public int SecondaryKitColorId { get; set; }

        public int TownId { get; set; }
    }
}
