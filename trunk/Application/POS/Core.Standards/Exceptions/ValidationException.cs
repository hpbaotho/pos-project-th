using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Standards.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException()
        {
            _Error = new List<Exception>();
        }
        private List<Exception> _Error;
        public List<Exception> Error { get { return _Error; } set { _Error = value; } }

    }
}
