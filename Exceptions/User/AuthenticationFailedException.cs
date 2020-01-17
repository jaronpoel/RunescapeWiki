using System;
using System.Collections.Generic;
using System.Text;

namespace Exceptions.User
{
    public class AuthenticationFailedException : Exception
    {
        public AuthenticationFailedException()
        {

        }

        public AuthenticationFailedException(string message) : base(message)
        {

        }
    }
}
