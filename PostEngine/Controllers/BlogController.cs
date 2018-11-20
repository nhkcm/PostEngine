using AutoMapper;
using PostEngine.Data;
using PostEngine.Logic.Interfaces;
using PostEngine.Logic.Utilities;
using PostEngine.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PostEngine.Controllers
{
    public class BlogController : ApiController
    {
        IPostManagerService pms;
        public BlogController(IPostManagerService _pms)
        {
            pms = _pms;
        }

        public Response<List<Post>> Get() {            
            var data = pms.GetResumePost();
            return data;
        }
    }
}
