using DAL.EF.Tables;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class LocationRepo : Repo, IRepo<Location, int, Location>
    {
        public Location Create(Location obj)
        {
            db.Locations.Add(obj);
            if(db.SaveChanges()>0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
           var ex = Get(id);
            if (ex != null)
            {
                db.Locations.Remove(ex);
                return db.SaveChanges() > 0;
            }
            return false;
        }

        public List<Location> Get()
        {
            return db.Locations.ToList();
        }

        public Location Get(int id)
        {
            return db.Locations.Find(id);
        }

        public Location Update(Location obj)
        {
            var ex = Get(obj.Id);
            if (ex == null) return null;

            db.Entry(ex).CurrentValues.SetValues(obj);
            db.SaveChanges();
            return obj;
        }

    }
}
