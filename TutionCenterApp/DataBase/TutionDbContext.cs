using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace TutionCenterApp.DataBase
{
    public class TutionDbContext : DbContext
    {
        public TutionDbContext(DbContextOptions<TutionDbContext>options): base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
