using System;
using System.Collections.Generic;
using System.Text;

namespace Exceptions.User
{
    public class RegistrationFailedException : Exception
    {
        public RegistrationFailedException()
        {

        }

        public RegistrationFailedException(string message) : base(message)
        {

        }
    }
}
