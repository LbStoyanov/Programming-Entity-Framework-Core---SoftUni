using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftUni.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Departments = new HashSet<Department>();
            EmployeesProjects = new HashSet<EmployeeProject>();
            InverseManager = new HashSet<Employee>();
        }

        [Key]
        [Column("EmployeeID")]
        public int EmployeeId { get; set; } 
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = null!;
        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = null!;
        [StringLength(50)]
        public string MiddleName { get; set; } = null!;
        [Required]
        [StringLength(50)]
        public string JobTitle { get; set; } = null!;
        [Column("DepartmentID")]
        public int DepartmentId { get; set; } 
        [Column("ManagerID")]
        public int? ManagerId { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime HireDate { get; set; }
        [Column(TypeName = "money")]
        public decimal Salary { get; set; }
        [Column("AddressID")]
        public int? AddressId { get; set; }

        [ForeignKey(nameof(AddressId))]
        [InverseProperty(nameof(Employee))]
        public virtual Address Address { get; set; } = null!;
        [ForeignKey(nameof(DepartmentId))]
        [InverseProperty("Employees")]
        public virtual Department Department { get; set; } = null!;
        [ForeignKey(nameof(ManagerId))]
        [InverseProperty(nameof(Employee.InverseManager))]
        public virtual Employee Manager { get; set; } = null!;
        [InverseProperty("Manager")]
        public virtual ICollection<Department> Departments { get; set; } = null!;
        [InverseProperty("Employee")]
        public virtual ICollection<EmployeeProject> EmployeesProjects { get; set; } = null!;
        [InverseProperty(nameof(Employee.Manager))]
        public virtual ICollection<Employee> InverseManager { get; set; } = null!;
    }
}
