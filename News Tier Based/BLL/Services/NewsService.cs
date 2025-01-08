using AutoMapper;
using BLL.DTOs;
using DAL.EF;
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
            //n.Date = DateTime.Now.Date;
            new NewsRepo().Create(GetMapper().Map<News>(n));
        }

        public static List<NewsDTO> GetAll()
        {
            return GetMapper().Map<List<NewsDTO>>(new NewsRepo().GetAll());
        }

        public static NewsDTO GetNews(int id)
        {
            return GetMapper().Map<NewsDTO>(new NewsRepo().GetNews(id));
        }

        public static void Delete(int id)
        {
            new NewsRepo().Delete(id);
        }

        public static void Update(NewsDTO n)
        {
            new NewsRepo().Update(GetMapper().Map<News>(n));
        }

        public static List<NewsDTO> NewsByTitle(string title)
        {
            return GetMapper().Map<List<NewsDTO>>(new NewsRepo().NewsByTitle(title));
        }

        public static List<NewsDTO> NewsByCategory(string title)
        {
            return GetMapper().Map<List<NewsDTO>>(new NewsRepo().NewsByCategory(title));
        }
        public static List<NewsDTO> NewsByDate(DateTime date)
        {
            return GetMapper().Map<List<NewsDTO>>(new NewsRepo().NewsByDate(date));
        }

        public static List<NewsDTO> NewsByDateCat(DateTime date, string category)
        {
            return GetMapper().Map<List<NewsDTO>>(new NewsRepo().NewsByDateCat(date, category));
        }

        public static List<NewsDTO> NewsByDateTitle(DateTime date, string title)
        {
            return GetMapper().Map<List<NewsDTO>>(new NewsRepo().NewsByDateCat(date, title));
        }





































    }
}
