using System.Data.Entity;
using EmployeeDBApplication.Models;

namespace EmployeeDBApplication.DataAccess
{
    public interface IEmployeeApplicationDB
    {
        DbSet<Department> Departments { get; set; }
        DbSet<Department_Position> Department_Position { get; set; }
        DbSet<Document> Documents { get; set; }
        DbSet<Employee> Employees { get; set; }
        DbSet<EmploymentHistory> EmploymentHistories { get; set; }
        DbSet<Position> Positions { get; set; }
        DbSet<TypeDocument> TypeDocuments { get; set; }
    }
    public partial class EmployeeApplicationDB : DbContext, IEmployeeApplicationDB
    {
        public EmployeeApplicationDB()
            : base("name=EmployeeApplicationDB")
        {
        }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Department_Position> Department_Position { get; set; }
        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmploymentHistory> EmploymentHistories { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<TypeDocument> TypeDocuments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                .Property(e => e.Rate)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Department>()
                .HasMany(e => e.Department_Position)
                .WithRequired(e => e.Department)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Department_Position>()
                .HasMany(e => e.Employees)
                .WithRequired(e => e.Department_Position)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Document>()
                .HasMany(e => e.Employees)
                .WithMany(e => e.Documents)
                .Map(m => m.ToTable("Employee_Document").MapLeftKey("Id_Document").MapRightKey("Id_Employee"));

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.EmploymentHistories)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Position>()
                .Property(e => e.Rate)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Position>()
                .HasMany(e => e.Department_Position)
                .WithRequired(e => e.Position)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TypeDocument>()
                .HasMany(e => e.Documents)
                .WithRequired(e => e.TypeDocument)
                .WillCascadeOnDelete(false);
        }
    }
}
