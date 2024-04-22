using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WinFormsApp5
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public int? ParentDepartmentId { get; set; }

        [ForeignKey("ParentDepartmentId")]
        public virtual Department ParentDepartment { get; set; }

        public virtual ICollection<Department> ChildDepartments { get; set; }
        public virtual ICollection<Position> Positions { get; set; }
    }
}
