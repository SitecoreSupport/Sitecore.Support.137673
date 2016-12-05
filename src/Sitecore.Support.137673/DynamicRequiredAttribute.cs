using Sitecore.Diagnostics;
using Sitecore.Form.Core.Configuration;
using Sitecore.Forms.Mvc.Interfaces;
using Sitecore.Forms.Mvc.Validators.Rules;
using Sitecore.Forms.Mvc.ViewModels.Fields;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;
using System.Linq;
using Sitecore.Globalization;
using System.Globalization;
using Sitecore.Forms.Mvc.ViewModels;

namespace Sitecore.Support.Forms.Mvc.Validators
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true), DisplayName("TITLE_ERROR_MESSAGE_FIELD_REQUIRED")]
    public class DynamicRequiredAttribute : Sitecore.Forms.Mvc.Validators.DynamicValidationBase
    {
        public DynamicRequiredAttribute()
        {
            base.EventId = IDs.Analytics.FieldNotCompletedEventId.ToString();
        }

        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            Sitecore.Diagnostics.Assert.ArgumentNotNull(metadata, "metadata");
            Sitecore.Diagnostics.Assert.ArgumentNotNull(context, "context");
            IHasIsRequired model = base.GetModel<IHasIsRequired>(metadata);
            if (model != null && model.IsRequired)
            {
                string errorMessage = this.FormatError(model, new object[0]);
                ModelClientValidationRule modelClientValidationRule;
                if (model is CheckboxField || model is CheckboxListField)
                {
                    modelClientValidationRule = new ModelClientValidationCheckedRule(errorMessage);
                }
                else
                {
                    modelClientValidationRule = new ModelClientValidationRequiredRule(errorMessage);
                }
                modelClientValidationRule.ValidationParameters.Add("tracking", base.EventId);
                yield return modelClientValidationRule;
            }
            yield break;
        }

        protected override ValidationResult ValidateFieldValue(IViewModel model, object value, ValidationContext validationContext)
        {
            Sitecore.Diagnostics.Assert.ArgumentNotNull(model, "model");
            Sitecore.Diagnostics.Assert.ArgumentNotNull(validationContext, "validationContext");
            IHasIsRequired hasIsRequired = model as IHasIsRequired;
            if (hasIsRequired == null || !hasIsRequired.IsRequired)
            {
                return ValidationResult.Success;
            }
            List<string> list = value as List<string>;
            if (list != null)
            {
                if (list.Count > 0)
                {
                    if (list.TrueForAll((string x) => !string.IsNullOrWhiteSpace(x)))
                    {
                        return ValidationResult.Success;
                    }
                }
                return new ValidationResult(this.FormatError(hasIsRequired, new object[0]));
            }
            if (value is bool)
            {
                if (!(bool)value)
                {
                    return new ValidationResult(this.FormatError(hasIsRequired, new object[0]));
                }
                return ValidationResult.Success;
            }
            else
            {
                HttpPostedFileBase httpPostedFileBase = value as HttpPostedFileBase;
                if (httpPostedFileBase != null && httpPostedFileBase.ContentLength > 0)
                {
                    return ValidationResult.Success;
                }
                string value2 = (value != null) ? value.ToString() : null;
                if (!string.IsNullOrWhiteSpace(value2))
                {
                    return ValidationResult.Success;
                }
                return new ValidationResult(this.FormatError(hasIsRequired, new object[0]));
            }
        }

        // Sitecore.Support.137673
        protected override string FormatError(object model, params object[] parameters)
        {
            Sitecore.Diagnostics.Assert.ArgumentNotNull(model, "model");
            FieldViewModel fieldViewModel = model as FieldViewModel;
            string text = string.Empty;
            if (fieldViewModel != null)
            {
                string errorMessageTemplate = this.GetErrorMessageTemplate(fieldViewModel);
                text = fieldViewModel.Title;
                if (!parameters.Any<object>())
                {
                    return string.Format(CultureInfo.CurrentCulture, errorMessageTemplate, new object[]
					{
						text
					});
                }
            }
            List<object> list = new List<object>
			{
				text
			};
            list.AddRange(parameters);
            return string.Format(CultureInfo.CurrentCulture, this.GetErrorMessageTemplate(fieldViewModel), list.ToArray());
        }

        public override string GetErrorMessageTemplate(object fieldModel)
        {
            string key = string.IsNullOrEmpty(this.ParameterName) ? base.GetType().Name : this.ParameterName;
            FieldViewModel fieldViewModel = (FieldViewModel)fieldModel;
            if (fieldViewModel != null)
            {
                Dictionary<string, string> parameters = fieldViewModel.Parameters;
                if (parameters.ContainsKey(key) && !String.IsNullOrEmpty(parameters[key]))
                {
                    return parameters[key];
                }
            }
            return Sitecore.Globalization.Translate.Text(base.ErrorMessageString);
        }
    }
}