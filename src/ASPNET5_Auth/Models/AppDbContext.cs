using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;

namespace ASPNET5_Auth.Models
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
