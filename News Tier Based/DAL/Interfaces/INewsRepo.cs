using DAL.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface INewsRepo
    {
        void Create(News n);
        List<News> GetAll();
        News GetNews(int id);
        void Delete(int id);
        void Update(News n);
        List<News> NewsByTitle(string title);
        List<News> NewsByCategory(string category);

        List<News> NewsByDate(DateTime date);
        List<News> NewsByDateTitle(DateTime date, string title);
        List<News> NewsByDateCat(DateTime date, string category);




    }
}
