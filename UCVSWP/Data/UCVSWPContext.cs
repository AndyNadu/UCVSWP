using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UCVSWP.Models;

namespace UCVSWP.Data
{
    public class UCVSWPContext : IdentityDbContext<IdentityUser>
    {
        public UCVSWPContext (DbContextOptions<UCVSWPContext> options)
            : base(options)
        {
        }

        public DbSet<UCVSWP.Models.Classroom> Classroom { get; set; } = default!;

        public DbSet<UCVSWP.Models.Announcement> Announcement { get; set; } = default!;

        public DbSet<UCVSWP.Models.Assignment> Assignment { get; set; } = default!;

        public DbSet<UCVSWP.Models.Comment> Comment { get; set; } = default!;

        public DbSet<UCVSWP.Models.Grade> Grade { get; set; } = default!;

        public DbSet<UCVSWP.Models.GradeAssignment> GradeAssignment { get; set; } = default!;

        public DbSet<UCVSWP.Models.Quiz> Quiz { get; set; } = default!;

        public DbSet<UCVSWP.Models.File> File { get; set; } = default!;
        public DbSet<UCVSWP.Models.UserClassroom> UserClassroom { get; set; }
    }
}
