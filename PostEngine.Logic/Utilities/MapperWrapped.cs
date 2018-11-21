using AutoMapper;
using PostEngine.Data;
using PostEngine.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostEngine.Logic.Utilities
{
    public class MapperWrapped
    {
        public MapperConfiguration mc;

        private static MapperWrapped instance;

        private MapperWrapped()
        {
            mc = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Post, PostDTO>();
                cfg.CreateMap<User, UserDTO>();
                cfg.CreateMap<Comments, CommentsDTO>();
            });
        }

        public static MapperWrapped Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MapperWrapped();
                }
                return instance;

            }
        }
    }
}
