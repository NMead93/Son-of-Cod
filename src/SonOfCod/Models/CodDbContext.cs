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
    }
}
