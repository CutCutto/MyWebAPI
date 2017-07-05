using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyWebAPI
{
    public class EmotionContext : DbContext
    {
        public EmotionContext(DbContextOptions<EmotionContext> options) : base(options)
        {

        }

        public DbSet<MouthModel> MouthModels { get; set; }
    }
}
