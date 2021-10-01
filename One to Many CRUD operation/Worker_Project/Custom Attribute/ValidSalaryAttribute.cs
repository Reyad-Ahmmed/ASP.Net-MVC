using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Worker_Project.Custom_Attribute
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ValidSalaryAttribute : ValidationAttribute, IClientValidatable
    {
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule
            {
                ErrorMessage = FormatErrorMessage(metadata.GetDisplayName()),
                ValidationType = "salary"
            };
            yield return rule;
        }
        public override bool IsValid(object value)
        {
            var data = decimal.Parse(value.ToString());
            return data >= 5000;
        }
    }
}