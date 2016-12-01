using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cultuurhuis3
{
   

public class DynamicRangeValidator : ValidationAttribute, IClientValidatable
{
    private readonly string _minPropertyName;
    private readonly string _maxPropertyName;
    public DynamicRangeValidator(string minPropertyName, string maxPropertyName)
    {
        _minPropertyName = minPropertyName;
        _maxPropertyName = maxPropertyName;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var minProperty = validationContext.ObjectType.GetProperty(_minPropertyName);
        var maxProperty = validationContext.ObjectType.GetProperty(_maxPropertyName);
        if (minProperty == null)
        {
            return new ValidationResult(string.Format("Unknown property {0}", _minPropertyName));
        }
        if (maxProperty == null)
        {
            return new ValidationResult(string.Format("Unknown property {0}", _maxPropertyName));
        }

        int minValue = (int)minProperty.GetValue(validationContext.ObjectInstance, null);
        int maxValue = (int)maxProperty.GetValue(validationContext.ObjectInstance, null);
        int currentValue = (int)value;
        if (currentValue <= minValue || currentValue >= maxValue)
        {
            return new ValidationResult(
                string.Format(
                    ErrorMessage, 
                    minValue,
                    maxValue
                )
            );
        }

        return null;
    }

    public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
    {
        var rule = new ModelClientValidationRule
        {
            ValidationType = "dynamicrange",
            ErrorMessage = this.ErrorMessage,
        };
        rule.ValidationParameters["minvalueproperty"] = _minPropertyName;
        rule.ValidationParameters["maxvalueproperty"] = _maxPropertyName;
        yield return rule;
    }
}
}