using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trucks.Data.Models
{
    public class ClientTruck
    {
        [Required]
        [ForeignKey(typeof(Client))]
        public int ClientId { get; set; }

        public virtual Client Client { get; set; } = null!;

        [Required]
        [ForeignKey(typeof(Truck))]
        public int TruckId { get; set; }

        public virtual Truck Truck { get; set; } = null!;
    }
}
