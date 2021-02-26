using System;
using System.Collections.Generic;
using System.Text;

namespace Click
{
    public class NoConnectionException : Exception
    {
        public NoConnectionException() : base() { }
        public NoConnectionException(string message) : base(message) { }
        public NoConnectionException(string message, Exception innerException) : base(message, innerException) { }
    }
}
