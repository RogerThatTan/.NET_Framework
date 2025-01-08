using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF;
using DAL.Interfaces;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class NewsService
    {   
       static INewsRepo solid = DataAccess.StudentDataAccess();
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<News, NewsDTO>();
                cfg.CreateMap<NewsDTO, News>();
            });
            var mapper = new Mapper(config);
            return mapper;
        }

        public static void Create(NewsDTO n) 
        {
             solid.Create(GetMapper().Map<News>(n));
        }

        public static List<NewsDTO> GetAll()
        {
            return GetMapper().Map<List<NewsDTO>>(solid.GetAll());
        }

        public static NewsDTO GetNews(int id)
        {
            return GetMapper().Map<NewsDTO>(solid.GetNews(id));
        }

        public static void Delete(int id)
        {
            solid.Delete(id);
        }

        public static void Update(NewsDTO n)
        {
            solid.Update(GetMapper().Map<News>(n));
        }

        public static List<NewsDTO> NewsByTitle(string title)
        {
            return GetMapper().Map<List<NewsDTO>>(solid.NewsByTitle(title));
        }

        public static List<NewsDTO> NewsByCategory(string title)
        {
            return GetMapper().Map<List<NewsDTO>>(solid.NewsByCategory(title));
        }
        public static List<NewsDTO> NewsByDate(DateTime date)
        {
            return GetMapper().Map<List<NewsDTO>>(solid.NewsByDate(date));
        }

        public static List<NewsDTO> NewsByDateCat(DateTime date, string category)
        {
            return GetMapper().Map<List<NewsDTO>>(solid.NewsByDateCat(date, category));
        }

        public static List<NewsDTO> NewsByDateTitle(DateTime date, string title)
        {
            return GetMapper().Map<List<NewsDTO>>(solid.NewsByDateCat(date,title));
        }

    }
}
