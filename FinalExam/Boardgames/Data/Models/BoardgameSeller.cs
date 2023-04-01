using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boardgames.Data.Models
{
    public class BoardgameSeller
    {
        [ForeignKey(nameof(BoardgameId))]
        public int BoardgameId { get; set; }

        public virtual BoardGame BoardGame { get; set; } = null!;

        [ForeignKey(nameof(Seller))]
        public int SellerId { get; set; }

        public virtual Seller Seller { get; set; } = null!;
    }
}
