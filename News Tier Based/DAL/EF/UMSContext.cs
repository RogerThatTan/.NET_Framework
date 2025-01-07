using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class UMSContext : DbContext
    {
        public DbSet<News> News { get; set; }
    }
}
