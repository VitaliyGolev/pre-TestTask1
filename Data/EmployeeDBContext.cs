using Microsoft.EntityFrameworkCore;
namespace BlazorServerAppTest.Data
{
    public partial class EmployeeDBContext : DbContext
    {
        public EmployeeDBContext()
        {

        }
        public EmployeeDBContext(DbContextOptions<EmployeeDBContext> options)
                : base(options)
        {

        }
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employees");
                entity.Property(e => e.employeeID).HasColumnName("ID");
                entity.Property(e => e.name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsRequired(true);
                entity.Property(e => e.age)
                    .IsRequired(true);
                entity.Property(e => e.email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsRequired(true);
                entity.Property(e => e.gender)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsRequired(false);
            });
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
