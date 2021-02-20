using ForestApp_IdentifiyApi_Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace ForestApp_IdentifiyApi_DataAccess
{
    public class IdentifiyApiDbContext: IdentityDbContext<ApplicationUser>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=ForestAppIdentifiyDb;Trusted_Connection=True;");
        }
   //     public IdentifiyApiDbContext(DbContextOptions<IdentifiyApiDbContext> options)
   //: base(options)
   //     {
   //     }
    }
}
