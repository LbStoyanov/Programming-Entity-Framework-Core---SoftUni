using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftUni.Models
{
    public partial class EmployeeProject
    {
        [Key]
        [Column("EmployeeID")]
        public int? EmployeeId { get; set; }
        [Key]
        [Column("ProjectID")]
        public int? ProjectId { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        [InverseProperty(nameof(EmployeeProject))]
        public virtual Employee Employee { get; set; } = null!;
        [ForeignKey(nameof(ProjectId))]
        [InverseProperty(nameof(EmployeeProject))]
        public virtual Project Project { get; set; } = null!;
    }
}
