using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms; // Добавляем пространство имен для использования оконных сообщений

namespace WinFormsApp5
{
    public class DepartmentRepository : IDisposable
    {
        private readonly AppDbContext _dbContext;

        public DepartmentRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public async Task<List<Department>> GetAllDepartmentsAsync()
        {
            return await _dbContext.Departments.ToListAsync();
        }

        public async Task<Department> GetDepartmentByIdAsync(int departmentId)
        {
            return await _dbContext.Departments.FindAsync(departmentId);
        }

        public async Task AddDepartmentAsync(Department department)
        {
            _dbContext.Departments.Add(department);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateDepartmentAsync(Department department)
        {
            if (department.DepartmentId == 1)
            {
                MessageBox.Show("Нельзя изменить корневую ветку.", "Ошибка изменения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Если пытаемся изменить заводоуправление выходим из метода
            }

            _dbContext.Entry(department).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Department>> GetChildDepartmentsAsync(int parentDepartmentId)
        {
            return await _dbContext.Departments.Where(d => d.ParentDepartmentId == parentDepartmentId).ToListAsync();
        }

        // Удаление вложенностей
        public async Task DeleteDepartmentAsync(int departmentId)
        {
            var department = await _dbContext.Departments.FindAsync(departmentId);
            if (department != null)
            {
                if (department.DepartmentId == 1)
                {
                    MessageBox.Show("Нельзя удалить корневую ветку.", "Ошибка удаления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Если пытаемся удалить заводоуправление, выходим из метода
                }

                // Удаляем все дочерние департаменты рекурсивно
                await DeleteChildDepartmentsAsync(departmentId);

                // Удаляем все должности, связанные с этим департаментом
                var positions = await _dbContext.Positions.Where(p => p.DepartmentId == departmentId).ToListAsync();
                _dbContext.Positions.RemoveRange(positions);

                // Удаляем родительский департамент
                _dbContext.Departments.Remove(department);

                await _dbContext.SaveChangesAsync();
            }
        }

        private async Task DeleteChildDepartmentsAsync(int parentDepartmentId)
        {
            var childDepartments = await _dbContext.Departments.Where(d => d.ParentDepartmentId == parentDepartmentId).ToListAsync();
            foreach (var childDepartment in childDepartments)
            {
                // Рекурсивное удаление дочерних департаментов
                await DeleteDepartmentAsync(childDepartment.DepartmentId);
            }
        }
    }
}
