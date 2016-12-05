using Sitecore.Forms.Mvc.Attributes;
using Sitecore.Forms.Mvc.Controllers.ModelBinders.FieldBinders;
using Sitecore.Forms.Mvc.Interfaces;
using Sitecore.Forms.Mvc.Validators;
using Sitecore.WFFM.Abstractions.Actions;
using System;
using Sitecore.Forms.Mvc.ViewModels;

namespace Sitecore.Support.Forms.Mvc.ViewModels
{
    public class ValuedFieldViewModel<TValue> : FieldViewModel, IFieldResult, IContainerMetadata
    {
        [ParameterName("Text"), PropertyBinder(typeof(DefaultFieldValueBinder)), Sitecore.Support.Forms.Mvc.Validators.DynamicRequired(ErrorMessage = "The {0} field is required."), MultiRegularExpression(null, "RegexPattern", ErrorMessage = "The value of the {0} field is not valid.")]
        public virtual TValue Value
        {
            get;
            set;
        }

        public virtual string ResultParameters
        {
            get;
            set;
        }

        public virtual ControlResult GetResult()
        {
            return new ControlResult(base.FieldItemId, this.Name, this.Value, this.ResultParameters, false);
        }

        public virtual void SetValueFromQuery(string valueFromQuery)
        {
            if (typeof(TValue) == typeof(string))
            {
                this.Value = (TValue)((object)valueFromQuery);
            }
        }
    }
}