using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftUni
{
    public partial class EmployeesProject
    {
        [Key]
        [Column("EmployeeID")]
        public int? EmployeeId { get; set; }
        [Key]
        [Column("ProjectID")]
        public int? ProjectId { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        [InverseProperty(nameof(EmployeesProject))]
        public virtual Employee Employee { get; set; } = null!;
        [ForeignKey(nameof(ProjectId))]
        [InverseProperty(nameof(EmployeesProject))]
        public virtual Project Project { get; set; } = null!;
    }
}
