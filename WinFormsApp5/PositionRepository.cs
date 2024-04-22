using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WinFormsApp5
{
    public class PositionRepository : IDisposable
    {
        private readonly AppDbContext _dbContext;

        public PositionRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public async Task<List<Position>> GetPositionsByDepartmentIdAsync(int departmentId)
        {
            return await _dbContext.Positions.Where(p => p.DepartmentId == departmentId).ToListAsync();
        }

        public async Task AddPositionAsync(Position position)
        {
            _dbContext.Positions.Add(position);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdatePositionAsync(Position position)
        {
            _dbContext.Entry(position).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeletePositionAsync(int positionId)
        {
            var position = await _dbContext.Positions.FindAsync(positionId);
            if (position != null)
            {
                _dbContext.Positions.Remove(position);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
