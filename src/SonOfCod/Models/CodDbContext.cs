using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SonOfCod.Models
{
    public class CodDbContext : IdentityDbContext<Admin>
    {
        public CodDbContext(DbContextOptions options) : base(options)
        {

        }

        public virtual DbSet<Subscriber> Subscribers { get; set; }
        public virtual DbSet<PageInfo> PageInfo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Cod;integrated security=True;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
