using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ChalkIt.Validation
{
    public class ValidationAttributes
    {
    }
    public class BooleanMustBeTrueAttribute : ValidationAttribute
    {
        public override bool IsValid(object propertyValue)
        {
            return propertyValue != null
                && propertyValue is bool
                && (bool)propertyValue;
        }
    }
}