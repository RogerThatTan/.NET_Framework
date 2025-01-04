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
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Course, CourseDTO>();
                cfg.CreateMap<CourseDTO, Course>();
            });
            var mapper = new Mapper(config);
            return mapper;
        }



        public static List<CourseDTO> Get()
        {
            //var data= new CourseRepo().Get();
            //var mapper = GetMapper();
            //var result = mapper.Map<List<CourseDTO>>(data);
            //return result;

            //this is the short cut version of above code
            return GetMapper().Map<List<CourseDTO>>(new CourseRepo().Get());
        }

        public static void Create(CourseDTO c)
        {
            //var repo = new CourseRepo();
            //var mapper = GetMapper();
            //var data = mapper.Map<Course>(c);
            //repo.Create(data);

            //this is the short cut version of above code
            new CourseRepo().Create(GetMapper().Map<Course>(c));


           
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
