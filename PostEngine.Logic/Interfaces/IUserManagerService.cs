using PostEngine.Data;
using PostEngine.Logic.Utilities;
using PostEngine.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostEngine.Logic.Interfaces
{
    public interface IUserManagerService
    {
        Response<UserDTO> Login(string name, string pass);
        Response<User> Create(User user);
        Response<string> GetToken(User user);
        Response<User> GetUserFromToken(string token);
        Response<bool> IsAdmin(User user);
    }
}
