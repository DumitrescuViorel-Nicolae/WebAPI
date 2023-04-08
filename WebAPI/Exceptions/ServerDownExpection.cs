using System;

namespace WebAPI.Exceptions
{
    public class ServerDownExpection : Exception
    {
        public ServerDownExpection(string message) : base(message) { }

        public string Message { get; set; }
    }
}
