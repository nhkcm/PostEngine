using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostEngine.Logic.Utilities
{
    public enum ResponseType
    {
        OK,
        ERROR
    }

    public static class ResponseFactory
    {
        public static Response<T> OK<T>(T content, string Message = "OK")
        {
            var r = new Response<T>();
            r.Content = content;
            r.Message = Message;
            r.ResponseType = ResponseType.OK;
            return r;
        }

        public static Response<T> ERROR<T>(T content, string Message = "has ocurred error")
        {
            var r = new Response<T>();
            r.Content = content;
            r.Message = Message;
            r.ResponseType = ResponseType.ERROR;
            return r;
        }

    }

    public class Response<T>
    {
        public string Message { get; set; }
        public T Content { get; set; }
        public ResponseType ResponseType { set; get; }
    }
}
