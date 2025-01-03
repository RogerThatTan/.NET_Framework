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
    public class CourseService
    {
        public static List<CourseDTO> Get()
        {
            var repo = new CourseRepo();
            var data = repo.Get();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Course, CourseDTO>();
            });
            var mapper = new Mapper(config);
            var result = mapper.Map<List<CourseDTO>>(data);
            return result;
        }

        public static void Create(CourseDTO c)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CourseDTO, Course>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Course>(c);
            var repo = new CourseRepo();
            repo.Create(data);
        }

        public static void Update(CourseDTO c)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CourseDTO, Course>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Course>(c);
            var repo = new CourseRepo();
            repo.Update(data);

        }
    }

}
