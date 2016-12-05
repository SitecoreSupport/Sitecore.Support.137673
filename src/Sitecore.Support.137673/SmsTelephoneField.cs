using Sitecore.Forms.Mvc.Validators;
using System;

namespace Sitecore.Support.Forms.Mvc.ViewModels.Fields
{
    public class SmsTelephoneField : Sitecore.Support.Forms.Mvc.ViewModels.Fields.TelephoneField
    {
        [DynamicRegularExpression("^\\+?\\d{3,}", null, ErrorMessage = "The {0} field contains an invalid sms/mms telephone number.")]
        public override string Value
        {
            get;
            set;
        }
    }
}