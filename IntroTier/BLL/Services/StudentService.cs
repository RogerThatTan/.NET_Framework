﻿using AutoMapper;
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
    public class StudentService
    {
        public static List<StudentDTO> Get()
        {
            var repo = new StudentRepo();
            var data = repo.Get();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Student, StudentDTO>();
            });

            var mapper = new Mapper(config);
            var result = mapper.Map<List<StudentDTO>>(data);
            return result;
        }

        public static void Create(StudentDTO s)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<StudentDTO, Student>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Student>(s);
            var repo = new StudentRepo();
            repo.Create(data);
        }
    }


}
