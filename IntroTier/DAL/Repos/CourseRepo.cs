using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class CourseRepo : Repo
    {
        
        public void Create(Course c)
        {
            db.Courses.Add(c);
            db.SaveChanges();
        }

        public List<Course> Get()
        {
            return db.Courses.ToList();
        }
        public Course Get(int id)
        {
            return db.Courses.Find(id);
        }
        public void Delete(int id)
        {
            var exobj = Get(id);
            db.Courses.Remove(exobj);
            db.SaveChanges();
        }
        public void Update(Course c)
        {
            var exobj = Get(c.Id);
            db.Entry(exobj).CurrentValues.SetValues(c);
            db.SaveChanges();
        }
    }

    }
