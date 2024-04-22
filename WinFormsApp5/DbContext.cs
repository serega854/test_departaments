using Microsoft.EntityFrameworkCore;

namespace WinFormsApp5
{
    public class AppDbContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-O5NO47I\\SQLEXPRESS;Database=Departmanents;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Установка каскадного удаления сотрудников при удалении должности
            modelBuilder.Entity<Position>()
                .HasMany(p => p.Employees)
                .WithOne(e => e.Position)
                .HasForeignKey(e => e.PositionId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Department>()
                .HasOne(d => d.ParentDepartment)
                .WithMany()
                .HasForeignKey(d => d.ParentDepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            // Добавление департамента "Заводоуправление" при миграции
            modelBuilder.Entity<Department>().HasData(
                new Department
                {
                    DepartmentId = 1,
                    Name = "Заводоуправление",
                    ParentDepartmentId = null
                }
            );
        }
    }
}
