using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TutionCenterApp.Entity;

namespace TutionCenterApp.Mapping
{
    public class StaffMapping : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.HasKey(staff=>staff.Id);
            builder.Property(staff => staff.Name).IsRequired();
            builder.Property(staff=>staff.Age).IsRequired();
            builder.Property(staff=>staff.DepartmentId).HasMaxLength(50);

            builder.HasOne(staff=>staff.Department).WithMany(staff=>staff.Staffs).HasForeignKey(staff=>staff.DepartmentId);

        }
    }
}
