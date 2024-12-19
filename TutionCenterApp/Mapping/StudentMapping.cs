using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TutionCenterApp.Entity;

namespace TutionCenterApp.Mapping
{
    public class StudentMapping : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(student => student.Id);
            builder.Property(student=>student.Name).IsRequired();
            builder.Property(student=>student.Age).IsRequired();
            builder.Property(student=>student.DepartmentId).HasMaxLength(50);

            builder.HasOne(student=>student.Department).WithMany(student=>student.Students).HasForeignKey(student=>student.DepartmentId);

        }
    }


}
