using System.Collections.Generic;
using System.Threading.Tasks;

namespace WinFormsApp5
{
    public interface IEmployeeRepository
    {
        Task<string> GetPositionTitleById(int positionId);
        Task<List<Employee>> GetEmployeesByPositionId(int positionId);
        Task<List<Employee>> GetEmployeesWithPositions();
        Task AddEmployee(Employee employee);
        //Task<List<Employee>> GetEmployeesByPositionIdWithPositionTitle(int positionId); // Добавляем новый метод
        Task<List<Employee>> GetEmployeesByPositionIdUpdateLoad(AppDbContext dbContext, int positionId);
        Task<string> GetPositionTitleByIdUpdateLoad(AppDbContext dbContext, int positionId);

    }
}
