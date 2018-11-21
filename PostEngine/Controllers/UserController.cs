using PostEngine.Logic.Interfaces;
using PostEngine.Logic.Utilities;
using PostEngine.Model.ApiObjects;
using PostEngine.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PostEngine.Controllers
{
    public class UserController : ApiController
    {
        IUserManagerService ums;
        public UserController(IUserManagerService _ums)
        {
            ums = _ums;
        }

        public Response<UserDTO> Login(LoginObj user) {
            var res = ums.Login(user.username, user.password);
            return res; 
        }

    }
}
