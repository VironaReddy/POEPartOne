using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using POEOne.Models;

namespace POEOne.Data
{
    public class POEOneContext : DbContext
    {
        public POEOneContext (DbContextOptions<POEOneContext> options)
            : base(options)
        {
        }

        public DbSet<POEOne.Models.ClaimApproval> ClaimApproval { get; set; } = default!;
        public DbSet<POEOne.Models.FileUpLoad> FileUpLoad { get; set; } = default!;
        public DbSet<POEOne.Models.Lecturer> Lecturer { get; set; } = default!;
        public DbSet<POEOne.Models.Status> Status { get; set; } = default!;
    }
}
