#nullable disable

using System.Collections.Generic;

namespace SoftUni.Models
{
    public partial class Department
    {
        public Department()
        {
            // ReSharper disable once VirtualMemberCallInConstructor
            Employees = new HashSet<Employee>();
        }

        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public int ManagerId { get; set; }

        public virtual Employee Manager { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
