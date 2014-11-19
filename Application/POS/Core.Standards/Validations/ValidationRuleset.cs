using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Standards.Validations
{
	public struct ValidationRuleset
	{
		public const string Insert = "Insert";
		public const string Update = "Update";
		public const string Delete = "Delete";
        public const string ReturnValue = "ReturnValue";
        public const string Validate = "Validate";
        public const string Generate = "Generate";
        public const string UpdateWorkType = "UpdateWorkType";
        public const string UpdatePM = "UpdatePM";
        public const string UpdatePCA = "UpdatePCA";
        public const string UpdateRemedialPlan = "UpdateRemedialPlan";
		public const string Submit = "Submit";
        public const string SaveAfterSubmit = "SaveAfterSubmit";
        public const string UpdatePCN = "UpdatePCN";
	}
}
