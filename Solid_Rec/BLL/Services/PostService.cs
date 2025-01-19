using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class PostService
    {   
        public static List<PostDTO> Get()
        {
            var data = DataAccessFactory.PostData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Post, PostDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<PostDTO>>(data); //jei variable ke map korbo sheta bracket e thakbe r <template> aikhane thakbe kishe map korbo
            return mapped;
       
        }

        public static PostDTO Get(int id)
        {
            var data = DataAccessFactory.PostData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Post, PostDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<PostDTO>(data);
            return mapped;
        }

        public static PostCommentDTO GetWithComments(int id)
        {
            var data = DataAccessFactory.PostData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Post, PostCommentDTO>(); //PostCommentDTO
                c.CreateMap<Comment, CommentDTO>();
                c.CreateMap<User, UserDTO>(); //user er details dekhar jonne map korsi and postcommentdto te user er property add korlam
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<PostCommentDTO>(data);
            return mapped;
        }


    }
}
