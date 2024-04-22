using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WinFormsApp5
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public DateTime HireDate { get; set; }

        public int PositionId { get; set; }

        [ForeignKey("PositionId")]
        public virtual Position Position { get; set; }
    }
}
