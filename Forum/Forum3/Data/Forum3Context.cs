using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Forum3.Models;

namespace Forum3.Data
{
    public class Forum3Context : DbContext
    {
        public Forum3Context (DbContextOptions<Forum3Context> options)
            : base(options)
        {
        }

        public DbSet<Forum3.Models.ForumTopic> ForumTopic { get; set; } = default!;
    }
}
