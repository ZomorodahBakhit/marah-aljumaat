using System;
using System.Collections.Generic;
using System.Text;

namespace University.Core.Exceptions
{
    public class BusinessException : Exception
    {
        public Dictionary<string, List<string>> Errors;
        public BusinessException(string message) : base(message)
        {
            Errors = new Dictionary<string, List<string>>();
        }
        public BusinessException(Dictionary<string, List<string>> errors)
        : base("One or more validation errors occurred.")
        {
            this.Errors = errors ?? new Dictionary<string, List<string>>();
        }
    }
}
