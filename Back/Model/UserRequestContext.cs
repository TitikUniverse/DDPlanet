using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIApp.Model
{
    public class UserRequestContext : DbContext
    {
        public UserRequestContext(DbContextOptions<UserRequestContext> options)
            : base(options)
        {
        }

        public DbSet<UserRequest> UserRequests { get; set; }
    }
}
