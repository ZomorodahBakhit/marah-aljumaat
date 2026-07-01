using System;
using System.Collections.Generic;
using System.Text;

namespace University.Core.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException() : this("Requested record not found.")
        {
        }
        public NotFoundException(string message) : base(message)
        {
        }
    }
}
