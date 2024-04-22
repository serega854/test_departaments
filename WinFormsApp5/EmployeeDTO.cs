using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp5
{
    public class EmployeeDTO
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime HireDate { get; set; }
        public int PositionId { get; set; }
        public string PositionTitle { get; set; } //для дополнительного вывода названия должности
    }
}
