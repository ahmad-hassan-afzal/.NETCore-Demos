using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Utilities
{
    public class ValidateEmailAttribute : ValidationAttribute
    {
        private readonly string allowedDomain;
        public ValidateEmailAttribute(string allowedDomain)
        {
            this.allowedDomain = allowedDomain;
        }
        public override bool IsValid(object value)
        {
            return value.ToString().Split('@')[1].ToLower() == allowedDomain.ToLower();
        }
    }
}
