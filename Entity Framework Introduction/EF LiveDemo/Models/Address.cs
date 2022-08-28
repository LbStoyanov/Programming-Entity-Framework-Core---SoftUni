using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftUni
{
    public partial class Address
    {
       
        public Address()
        {
            Employees = new HashSet<Employee>();
        }

        [Key]
        [Column("AddressID")]
        public int AddressId { get; set; }
        [Required]
        [StringLength(100)]
        public string AddressText { get; set; } = null!;
        [Column("TownID")]
        public int? TownId { get; set; }

        [ForeignKey(nameof(TownId))]
        [InverseProperty(nameof(Address))]
        public virtual Town Town { get; set; } = null!;
        [InverseProperty("Address")]
        public virtual ICollection<Employee> Employees { get; set; } = null!;
    }
}
