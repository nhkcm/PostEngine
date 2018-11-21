using AutoMapper;
using PostEngine.Data;
using PostEngine.Logic.Interfaces;
using PostEngine.Logic.Utilities;
using PostEngine.Model.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostEngine.Logic.Services
{
    public class PostManagerService : IPostManagerService
    {
        IMapper mapper;
        /// <summary>
        /// context to data access
        /// </summary>
        DBPostEngineEntities ctx;
        /// <summary>
        /// default constructor
        /// </summary>
        public PostManagerService()
        {
            ctx = new DBPostEngineEntities();
            mapper = MapperWrapped.Instance.mc.CreateMapper();
        }
        /// <summary>
        /// this method change state to Aproval or disaproval
        /// </summary>
        /// <param name="post">entity to aproval, this must be contains id record</param>
        /// <returns>Response in ok or error with message error</returns>
        public Response<string> AprovalPost(Post post)
        {
            try
            {
                var epost = ctx.Post.Find(post.id);
                epost.state = (byte)PostStates.APPROVED;
                ctx.Entry(epost).State = EntityState.Modified;
                var changes = ctx.SaveChanges();

                if (changes == 1)
                    return ResponseFactory.OK("Post approved");
                else
                    return ResponseFactory.OK("Without Changes");

            }
            catch (Exception ex)
            {
                return ResponseFactory.ERROR(ex.Message);
            }
        }
        /// <summary>
        /// this method create new post
        /// </summary>
        /// <param name="post">entity to create</param>
        /// <returns>Response in ok or error with message error</returns>
        public Response<string> CreatePost(Post post)
        {
            try
            {
                post.id = -1;
                post.state = (byte)PostStates.PENDING;
                ctx.Post.Add(post);                
                var changes = ctx.SaveChanges();
                if (changes == 1)
                    return ResponseFactory.OK("Post created");
                else
                    return ResponseFactory.OK("Post has not created");

            }
            catch (Exception ex)
            {
                return ResponseFactory.ERROR(ex.Message);
            }
        }
        /// <summary>
        /// delete post if not pending
        /// </summary>
        /// <param name="post"></param>
        /// <returns>Response in ok or error with message error</returns>
        public Response<string> DeletePost(Post post)
        {
            try
            {
                if (post.state == (byte)PostStates.PENDING)
                    return ResponseFactory.ERROR("Post pending can't be deleted");
                    

                var epost = ctx.Post.Find(post.id);
                ctx.Post.Remove(epost);
                var changes = ctx.SaveChanges();

                if (changes == 1)
                    return ResponseFactory.OK("Post delete");
                else
                    return ResponseFactory.OK("Post has not delete");

            }
            catch (Exception ex)
            {
                return ResponseFactory.ERROR(ex.Message);
            }
        }
        /// <summary>
        /// this method can edit title, text and privacy of posts
        /// </summary>
        /// <param name="post"></param>
        /// <returns>Response in ok or error with message error</returns>
        public Response<string> EditPost(Post post)
        {
            try
            {
               
                var epost = ctx.Post.Find(post.id);
                epost.title = post.title;
                epost.text = post.text;
                epost.is_public = post.is_public;

                ctx.Entry(epost).State = EntityState.Modified;
                var changes = ctx.SaveChanges();

                if (changes == 1)
                    return ResponseFactory.OK("Post delete");
                else
                    return ResponseFactory.OK("Post has not delete");

            }
            catch (Exception ex)
            {
                return ResponseFactory.ERROR(ex.Message);
            }
        }
        /// <summary>
        /// this method get all pending post for aproval
        /// </summary>
        /// <returns>Response in ok or error with message error</returns>
        public Response<List<PostDTO>> GetPendingForAprovalPost()
        {
            try
            {
                var dataPost = ctx.Post
                    .Where(w => w.state == (byte)PostStates.PENDING)                    
                    .ToList();
                return ResponseFactory.OK(mapper.Map<List<PostDTO>>(dataPost));
            }
            catch (Exception ex)
            {
                return ResponseFactory.ERROR(new List<PostDTO>(),ex.Message);
            }
        }
        /// <summary>
        /// this method get post by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Response in ok or error with message error</returns>
        public Response<PostDTO> GetPost(int id)
        {
            try
            {
                var dataPost = ctx.Post
                    .Find(id);
                return ResponseFactory.OK(mapper.Map<PostDTO>(dataPost));
            }
            catch (Exception ex)
            {
                return ResponseFactory.ERROR(new PostDTO(), ex.Message);
            }
        }
        /// <summary>
        /// this method get public post
        /// </summary>
        /// <returns></returns>
        public Response<List<PostDTO>> GetPublicPost()
        {
            try
            {
                var dataPost = ctx.Post
                    .Include("User")
                    .Where(w => w.is_public == 1 && w.state == (byte)PostStates.APPROVED)
                    .ToList();
                return ResponseFactory.OK(mapper.Map<List<PostDTO>>(dataPost));
            }
            catch (Exception ex)
            {
                return ResponseFactory.ERROR(new List<PostDTO>(), ex.Message);
            }
        }
        /// <summary>
        /// this method get all posts
        /// </summary>
        /// <returns>Response in ok or error with message error</returns>
        public Response<List<PostDTO>> GetResumePost(int id)
        {
            try
            {
                var dataPost = ctx.Post               
                    .Include("User")
                    .Where(w => w.user_id == id || w.state == (byte)PostStates.APPROVED)
                    .ToList();
                return ResponseFactory.OK(mapper.Map<List<PostDTO>>(dataPost));
            }
            catch (Exception ex)
            {
                return ResponseFactory.ERROR(new List<PostDTO>(), ex.Message);
            }
        }
        /// <summary>
        /// this method get all posts
        /// </summary>
        /// <returns>Response in ok or error with message error</returns>
        public Response<List<PostDTO>> GetResumePostEditor()
        {
            try
            {
                var dataPost = ctx.Post
                    .Include("User")
                    .ToList();
                return ResponseFactory.OK(mapper.Map<List<PostDTO>>(dataPost));
            }
            catch (Exception ex)
            {
                return ResponseFactory.ERROR(new List<PostDTO>(), ex.Message);
            }
        }
        /// <summary>
        /// this method add comment to post
        /// </summary>
        /// <param name="comments"></param>
        /// <returns></returns>
        public Response<string> SaveComment(Comments comments)
        {
            try
            {
                comments.id = -1;
                comments.created = DateTime.Now;
                ctx.Comments.Add(comments);
                var changes = ctx.SaveChanges();
                if (changes == 1)
                    return ResponseFactory.OK("Comment created");
                else
                    return ResponseFactory.OK("Comment has not created");

            }
            catch (Exception ex)
            {
                return ResponseFactory.ERROR(ex.Message);
            }
        }
    }
}
