using PostEngine.Data;
using PostEngine.Logic.Interfaces;
using PostEngine.Logic.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostEngine.Logic.Services
{
    public class UserManagerService : IUserManagerService
    {
        /// <summary>
        /// context for access to data
        /// </summary>
        DBPostEngineEntities ctx;
        /// <summary>
        /// default constructor
        /// </summary>
        public UserManagerService()
        {
            ctx = new DBPostEngineEntities();
        }
        /// <summary>
        /// this method create new user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Response<User> Create(User user)
        {
            try
            {
                ctx.User.Add(user);
                var changes = ctx.SaveChanges();

                if (changes == 1)
                    return ResponseFactory.OK(user, "user created");
                else
                    return ResponseFactory.OK(user, "user has not created");
            }
            catch (Exception ex)
            {
                return ResponseFactory.ERROR(new User(), ex.Message);
            }
        }
        /// <summary>
        /// this method get token from user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Response<string> GetToken(User user)
        {
            try
            {
                string token = Jose.JWT.Encode(user, "anysecretkey", Jose.JwsAlgorithm.RS512);
                return ResponseFactory.OK(token);
            }
            catch (Exception ex)
            {
                return ResponseFactory.ERROR(ex.Message);
            }
        }
        /// <summary>
        /// this method get information from user by a token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Response<User> GetUserFromToken(string token)
        {
            try
            {
                var user = Jose.JWT.Decode<User>(token, "anysecretkey", Jose.JwsAlgorithm.RS512);
                return ResponseFactory.OK(user);
            }
            catch (Exception ex)
            {
                return ResponseFactory.ERROR(new User(), ex.Message);
            }
        }
        /// <summary>
        /// check if user is editor
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Response<bool> IsAdmin(User user)
        {
            if (user.rol == "editor")
            {
                return ResponseFactory.OK(true);
            }
            else
            {
                return ResponseFactory.OK(false);
            }
        }
        /// <summary>
        /// check login for users
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        public Response<User> Login(string name, string pass)
        {
            try
            {
                var user = ctx.User.Where(w => w.name == name && w.pass == pass).FirstOrDefault();
                if (user != null)
                {
                    return ResponseFactory.OK(user);
                }
                else
                {
                    return ResponseFactory.ERROR(new User(), "no login");
                }
            }
            catch (Exception ex)
            {
                return ResponseFactory.ERROR(new User(), ex.Message);
            }
        }
    }
}
