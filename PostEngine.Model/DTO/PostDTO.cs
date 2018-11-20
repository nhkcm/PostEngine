using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostEngine.Model.DTO
{
    public class PostDTO
    {
        public int id;
        public string title;
        public string text;
        public DateTime created;
        public DateTime last_updated;
        public bool is_public;
        public byte state;
        public List<CommentsDTO> comments { get; set; } = new List<CommentsDTO>();
    }
}
