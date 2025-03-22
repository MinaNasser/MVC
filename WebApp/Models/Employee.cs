using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApp.Models;



namespace WebApp.Models
{
    public class Employee
    {
        [Key]

        public int Id { get; set; }

        [Display(Name="Employee Name")]
        [Required]
        [MaxLength(30)]
        [MinLength(3)]
        [UniqName(msg ="Enter Uniq Name Please")]
        public string Name { get; set; }
        [Required]
        [Range(minimum: 3000,maximum: 10000)]
        public int Salary { get; set; }
        public string JobTitle { get; set; }
        [Required]
        [RegularExpression(@"\w+\.(jpg|png)", ErrorMessage = "Image Must be .jpg or .png ")]
        public string ImageURL { get; set; }

        [Required]
        [RegularExpression(@"[a-zA-Z]{3,}")]
        public string Address { get; set; }
        [ForeignKey("Department")]
        [Display(Name= "Department")]
        public int DepartmentId { get; set; }
        public virtual Department? Department { get; set; }
    }
}
// Add Configuration for Employees Table with Fluent API
public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("Employees");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Name).IsRequired().HasMaxLength(50);
        builder.Property(e => e.Salary).IsRequired();
        builder.Property(e => e.JobTitle).IsRequired().HasMaxLength(50);
        builder.Property(e => e.ImageURL).IsRequired().HasMaxLength(200);
        builder.Property(e => e.Address).IsRequired().HasMaxLength(200);
        builder.HasOne(e => e.Department)
        .WithMany(d => d.Employees)
        .HasForeignKey(e => e.DepartmentId)
        .OnDelete(DeleteBehavior.NoAction);
    }
}