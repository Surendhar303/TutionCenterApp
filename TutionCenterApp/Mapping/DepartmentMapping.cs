using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TutionCenterApp.Entity;

namespace TutionCenterApp.Mapping
{
    public class DepartmentMapping : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(dept=>dept.Id);
            builder.Property(dept => dept.Name).IsRequired();
        }
    }
}
