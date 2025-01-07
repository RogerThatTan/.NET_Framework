using DAL.EF;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class NewsRepo : Repo
    {
        public void Create(News n)
        {
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
            return db.News.Where(n => n.Date == date).ToList();
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
