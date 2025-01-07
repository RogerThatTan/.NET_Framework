using DAL.EF;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class NewsRepo : Repo
    {
        public void Create(News n)
        {
            //var date = System.DateTime.Now;
            //n.Date = date.Date;
            db.News.Add(n);
            db.SaveChanges();
        }

        public List<News> GetAll()
        {
            return db.News.ToList();
        }

        public News Get(int id)
        {
            return db.News.Find(id);
        }

        public void Update(News n)
        {
            var existing  = Get(n.Id);
            db.Entry(existing).CurrentValues.SetValues(n);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var exisiting = Get(id);
            db.News.Remove(exisiting);
            db.SaveChanges();
        }

        public List<News> GetByDate(DateTime date)
        {

            var rest = (from n in db.News
                        where n.Date == date
                        select n).ToList();
            return rest;

            //return db.News.Where(n => n.Date == date).ToList();
        }

        public List<News> GetByCategory(string category)
        {
            return db.News.Where(n => n.Category == category).ToList();
        }

        public List<News> GetByTitle(string title)
        {
            return db.News.Where(n => n.Title == title).ToList();
        }

        public List<News> GetByTitleAndCategory(string title, string category)
        {
            return db.News.Where(n => n.Title == title && n.Category == category).ToList();
        }
    }
}
