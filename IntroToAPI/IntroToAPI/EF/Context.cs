using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IntroToAPI.EF
{
    public class Context : DbContext
    {
        public DbSet<Course> Courses { get; set; }
    }
}