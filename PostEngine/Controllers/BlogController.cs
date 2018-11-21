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

        [HttpGet]
        [Route("api/Blog/{user_id}")]
        public Response<List<PostDTO>> Get(int user_id)
        {
            var data = pms.GetResumePost(user_id);
            return data;
        }

        [HttpGet]
        [Route("api/Blog")]
        public Response<List<PostDTO>> Get()
        {
            var data = pms.GetResumePostEditor();
            return data;
        }

        [HttpGet]
        [Route("api/Blog/public")]        
        public Response<List<PostDTO>> GetPublic()
        {
            var data = pms.GetPublicPost();
            return data;
        }

        [HttpPost]
        [Route("api/Blog")]
        public Response<string> CreatePost(Post post) {
            post.created = DateTime.Now;
            post.last_update = DateTime.Now;
            post.state = (byte)PostStates.PENDING;
            var data = pms.CreatePost(post);
            return data;
        }

        [HttpPost]
        [Route("api/Blog/Comment")]
        public Response<string> CreateComment(Comments comments)
        {            
            var data = pms.SaveComment(comments);
            return data;
        }

        [HttpPut]
        [Route("api/Blog/{id}")]
        public Response<string> UpdatePost(int id)
        {
            var post = new Post();
            post.id = id;
            var data = pms.AprovalPost(post);            
            return data;
        }
    }
}
