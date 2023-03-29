using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trucks.Common;
using Trucks.Data.Models.Enums;

namespace Trucks.Data.Models
{
    public class Truck
    {
        public Truck()
        {
            this.ClientTrucks = new HashSet<ClientTruck>();
        }

        [Key]
        public int Id { get; set; }


        [MaxLength(ValidationConstatnts.RegistrationNumberLength)]
        public string? RegistrationNumber { get; set; }

        [Required]
        [MaxLength(ValidationConstatnts.VinNumberLength)]
        public string VinNumber { get; set; }

        
        public int TankCapacity  { get; set;}

        public int CargoCapacity { get; set; }

        [Required]
        public CategoryType CategoryType {get; set; }

        [Required]
        public MakeType MakeType { get; set; }

        
        [ForeignKey(nameof(Despatcher))]
        public int DespatcherId { get; set; }


        public virtual Despatcher Despatcher { get; set; } = null!;

        public ICollection<ClientTruck> ClientTrucks { get; set; }
    }
}
