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
            new NewsRepo().Create(GetMapper().Map<News>(n));
        }
        public static List<NewsDTO> GetAll()
        {
            return GetMapper().Map<List<NewsDTO>>(new NewsRepo().GetAll());
        }
        public NewsDTO Get(int id)
        {
            return GetMapper().Map<NewsDTO>(new NewsRepo().Get(id));
        }
        public static void Delete(int id)
        {
            new NewsRepo().Delete(id);
        }
        public static void Update(NewsDTO n)
        {
            new NewsRepo().Update(GetMapper().Map<News>(n));

        }

        public static List<NewsDTO> GetByCategory(string category)
        {
            return GetMapper().Map<List<NewsDTO>>(new NewsRepo().GetByCategory(category));
        }

        public static List<NewsDTO> GetByTitle(string title)
        {
            return GetMapper().Map<List<NewsDTO>>(new NewsRepo().GetByTitle(title));
        }

        public static List<NewsDTO> GetByTitleAndCategory(string title, string category)
        {
            return GetMapper().Map<List<NewsDTO>>(new NewsRepo().GetByTitleAndCategory(title, category));
        }

        public static List<NewsDTO> GetByDate(DateTime date)
        {
            return GetMapper().Map<List<NewsDTO>>(new NewsRepo().GetByDate(date));
        }













    }
}
