using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Standards.Validations
{
    public class ValidationError
    {
        public ValidationError(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
        public ValidationError(int errorNo, string errorMessage)
        {
            ErrorNo = errorNo;
            ErrorMessage = errorMessage;
        }
        public ValidationError(string errorGroup,int errorNo, string errorMessage)
        {
            ErrorNo = errorNo;
            ErrorMessage = errorMessage;
            ErrorGroup = errorGroup;
        }
        public string ErrorMessage { get; set; }
        public int ErrorNo { get; set; }
        public string ErrorGroup { get; set; }
        
    }
}
