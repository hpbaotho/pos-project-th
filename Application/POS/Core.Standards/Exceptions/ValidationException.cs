using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Standards.Validations;
using Microsoft.Practices.EnterpriseLibrary.Validation;

namespace Core.Standards.Exceptions
{
    public class ValidationException : Exception
    {
        #region Property
        public List<string> ValidationErrors { get; private set; }
        public bool IsEmpty
        {
            get
            {
                if (this.ValidationErrors == null) return true;
                if (this.ValidationErrors.Count == 0) return true;

                return false;
            }
        }

        public List<ValidationError> Errors { get; set; }

        #endregion

        #region Constructor

        public ValidationException()
        {
            this.ValidationErrors = new List<string>();
            this.Errors = new List<ValidationError>();
        }
        public ValidationException(List<ValidationError> errors)
        {
            this.Errors = errors;
        }
        public ValidationException(ValidationResults validationResults)
            : this()
        {
            this.MergeErrors(validationResults);
        }
        public ValidationException(string errorMesage, params object[] param)
            : this()
        {
            this.AddError(errorMesage, param);
        }
        public ValidationException(IList<string> errorMessages)
            : this()
        {
            this.MergeErrors(errorMessages);
        }
        public ValidationException(Exception exception)
            : this()
        {
            this.AddError(exception);
        }
        #endregion

        #region Add Error
        public void AddError(string errorMessage, params object[] param)
        {
            if ((param != null) && (param.Length > 0))
            {
                errorMessage = string.Format(errorMessage, param);
            }

            this.ValidationErrors.Add(errorMessage);
            this.Errors.Add(new ValidationError(this.Errors.Count + 1, errorMessage));
        }
        public void AddError(string errorGroup, string errorMessage, params object[] param)
        {
            if ((param != null) && (param.Length > 0))
            {
                errorMessage = string.Format(errorMessage, param);
            }

            this.ValidationErrors.Add(errorMessage);
            this.Errors.Add(new ValidationError(errorGroup, this.Errors.Count + 1, errorMessage));
        }
        public void MergeErrors(IList<string> errorMessages)
        {
            this.ValidationErrors.AddRange(errorMessages);

            foreach (string errorMessage in errorMessages)
                this.Errors.Add(new ValidationError(this.Errors.Count + 1, errorMessage));
        }
        public void MergeErrors(ValidationResults validationResults)
        {
            if ((validationResults != null) && (!validationResults.IsValid))
            {
                foreach (ValidationResult validationResult in validationResults)
                {
                    this.ValidationErrors.Add(validationResult.Message);
                    this.Errors.Add(new ValidationError(this.Errors.Count + 1, validationResult.Message));
                }
            }
        }
        public void AddError(Exception exception)
        {
            if (exception != null)
            {
                this.ValidationErrors.Add(exception.ToString());
                this.Errors.Add(new ValidationError(this.Errors.Count + 1, exception.ToString()));
            }
        }
        #endregion

        #region Clear Error
        public void Clear()
        {
            this.ValidationErrors.Clear();
            this.Errors.Clear();
        }
        #endregion

        public IList<string> errorMessages { get; set; }

    }
}
