using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp5
{
    public static class EmployeeMapper
    {
        public static EmployeeDTO MapToDTO(Employee employee)
        {
            return new EmployeeDTO
            {
                EmployeeId = employee.EmployeeId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                MiddleName = employee.MiddleName,
                HireDate = employee.HireDate,
                PositionId = employee.PositionId,
                PositionTitle = employee.Position != null ? employee.Position.Title : "Нет должности"
            };
        }

    }
}
