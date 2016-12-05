using Sitecore.Forms.Mvc.Attributes;
using Sitecore.StringExtensions;
using Sitecore.WFFM.Abstractions.Actions;
using System;
using System.ComponentModel.DataAnnotations;

namespace Sitecore.Support.Forms.Mvc.ViewModels.Fields
{
    public class CreditCardField : Sitecore.Support.Forms.Mvc.ViewModels.Fields.SingleLineTextField
    {
        [ParameterName("CardNumberHelp")]
        public override string Information
        {
            get;
            set;
        }

        [CreditCard]
        public override string Value
        {
            get;
            set;
        }

        public CreditCardField()
        {
            base.Tracking = false;
        }

        public override ControlResult GetResult()
        {
            return new ControlResult(base.FieldItemId, this.Title, this.Value, "secure:<schidden>{0}</schidden>".FormatWith(new object[]
			{
				this.Value
			}), true);
        }

        public override void SetValueFromQuery(string valueFromQuery)
        {
        }
    }
}