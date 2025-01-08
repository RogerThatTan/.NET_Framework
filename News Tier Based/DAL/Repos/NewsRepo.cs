using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class NewsRepo : Repo
    {
        public  void Create(News n)
        {
            db.News.Add(n);
            db.SaveChanges();
        }

        public List<News> GetAll()
        {
            return db.News.ToList();
        }

        public News GetNews(int id)
        {
            return db.News.Find(id);
        }

        public void Delete(int id)
        {
           var n = GetNews(id);
            db.News.Remove(n);
            db.SaveChanges();
        }

        public  void Update(News n)
        {
            var existing = GetNews(n.Id);
            db.Entry(existing).CurrentValues.SetValues(n);
            db.SaveChanges();
        }

        //API Features :

        public List<News>NewsByTitle(string title)
        {
            var ret = (from n in db.News
                       where n.Title.Contains(title)
                       select n).ToList();
            return ret;
        }


        public List<News> NewsByCategory(string category)
        {
            var ret = (from n in db.News
                       where n.Category.Contains(category)
                       select n).ToList();
            return ret;
        }

        public List<News> NewsByDate(DateTime date)
        {
            var ret = (from n in db.News
                       where n.Date == date
                       select n).ToList();
            return ret;
        }

        public List<News> NewsByDateCat(DateTime date, string category)
        {
            var ret = (from n in db.News
                       where n.Date == date && n.Category.Contains(category)
                       select n).ToList();
            return ret;
        }
        public List<News> NewsByDateTitle(DateTime date, string title)
        {
            var ret = (from n in db.News
                       where n.Date == date && n.Title.Contains(title)
                       select n).ToList();
            return ret;
        }



    }
}
