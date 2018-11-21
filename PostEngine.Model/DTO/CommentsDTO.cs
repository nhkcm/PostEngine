using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostEngine.Model.DTO
{
    public class CommentsDTO
    {
        public int id;
        public DateTime created;
        public string author_name;
        public string email;
        public string text;
    }
}
