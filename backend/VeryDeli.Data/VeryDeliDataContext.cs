using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VeryDeli.Data.Domains;

namespace VeryDeli.Data
{
    public class VeryDeliDataContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public VeryDeliDataContext(DbContextOptions options) : base(options)
        {
        }
    }
}
