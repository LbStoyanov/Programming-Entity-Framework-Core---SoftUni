using P03_FootballBetting.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace P03_FootballBetting.Data.Models
{
    public class Bet
    {
        [Key]
        public int BetId { get; set; }

        public decimal Amount { get; set; }

        public DateTime DateTime { get; set; }

        public int UserId { get; set; }
        public int GameId { get; set; }

        [Required]
        public Prediction Prediction { get; set; }
    }
}
