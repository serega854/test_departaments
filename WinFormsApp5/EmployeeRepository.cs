using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WinFormsApp5
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _dbContext;

        public EmployeeRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Employee>> GetEmployeesByPositionId(int positionId)
        {
            return await _dbContext.Employees
                                   .Include(e => e.Position) // Включаем связанную должность
                                   .Where(e => e.PositionId == positionId)
                                   .ToListAsync();
        }



        public async Task<List<Employee>> GetEmployeesWithPositions()
        {
            return await _dbContext.Employees
                                   .Include(e => e.Position)
                                   .ToListAsync();
        }

        public async Task AddEmployee(Employee employee)
        {
            _dbContext.Employees.Add(employee);
            await _dbContext.SaveChangesAsync();
        }

        // Добавляем метод для получения названия должности по ее идентификатору
        public async Task<string> GetPositionTitleById(int positionId)
        {
            var position = await _dbContext.Positions.FindAsync(positionId);
            return position != null ? position.Title : null;
        }

        public async Task<List<Employee>> GetEmployeesByPositionIdUpdateLoad(AppDbContext dbContext, int positionId)
        {
            return await dbContext.Employees.Where(e => e.PositionId == positionId).ToListAsync();
        }

        public async Task<string> GetPositionTitleByIdUpdateLoad(AppDbContext dbContext, int positionId)
        {
            Position position = await dbContext.Positions.FindAsync(positionId);
            return position != null ? position.Title : null;
        }
    }
}
