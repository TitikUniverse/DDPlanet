using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIApp.Model
{
    public class FormUserContext : DbContext
    {
        public FormUserContext(DbContextOptions<FormUserContext> options)
            : base(options)
        {
        }

        public DbSet<FormUser> FormUsers { get; set; }
    }
}
