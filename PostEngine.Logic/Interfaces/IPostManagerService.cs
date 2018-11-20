using PostEngine.Data;
using PostEngine.Logic.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostEngine.Logic.Interfaces
{
    public interface IPostManagerService
    {  
        Response<string> CreatePost(Post post);
        Response<string> EditPost(Post post);
        Response<string> DeletePost(Post post);
        Response<string> AprovalPost(Post post);
        Response<List<Post>> GetPendingForAprovalPost();
        Response<List<Post>> GetResumePost();
        Response<Post> GetPost(int id);
    }
}
