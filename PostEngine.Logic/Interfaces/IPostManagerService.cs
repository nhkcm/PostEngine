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
    public interface IPostManagerService
    {  
        Response<string> CreatePost(Post post);
        Response<string> EditPost(Post post);
        Response<string> DeletePost(Post post);
        Response<string> AprovalPost(Post post);
        Response<List<PostDTO>> GetPendingForAprovalPost();
        Response<List<PostDTO>> GetResumePost(int id);
        Response<List<PostDTO>> GetResumePostEditor();
        Response<List<PostDTO>> GetPublicPost();
        Response<PostDTO> GetPost(int id);
        Response<string> SaveComment(Comments comments);

    }
}
