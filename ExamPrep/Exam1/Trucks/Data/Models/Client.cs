using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trucks.Common;

namespace Trucks.Data.Models
{
    public class Client
    {
        public Client()
        {
            this.ClientTrucks = new HashSet<ClientTruck>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstatnts.ClientNameLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(ValidationConstatnts.NationalityLength)]
        public string Nationality { get; set; }

        [Required]
        public string Type { get; set; }


        public ICollection<ClientTruck> ClientTrucks { get; set; }
    }
}
