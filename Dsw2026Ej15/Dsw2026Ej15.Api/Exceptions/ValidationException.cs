using System;
using System.Collections.Generic;
using System.Linq;


namespace Dsw2026Ej15.Api.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException(string message) : base(message)
        {

        }
    
    }
}