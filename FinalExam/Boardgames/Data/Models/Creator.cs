
using System.ComponentModel.DataAnnotations;

namespace Boardgames.Data.Models
{
    public class Creator
    {
        public Creator()
        {
            this.BoardGames = new HashSet<BoardGame>();
        }

        [Key]
        public int Id { get; set; }

        [Required] 
        [MaxLength(7)] 
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(7)]
        public string LastName { get; set; } = null!;

        public virtual ICollection<BoardGame>BoardGames { get; set; }
    }
}
