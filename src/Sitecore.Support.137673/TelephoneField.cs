using Sitecore.Forms.Mvc.Validators;
using Sitecore.WFFM.Abstractions.Actions;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Sitecore.Support.Forms.Mvc.ViewModels.Fields
{
    public class TelephoneField : Sitecore.Support.Forms.Mvc.ViewModels.Fields.SingleLineTextField
    {
        [DynamicRegularExpression("^\\+?\\s{0,}\\d{0,}\\s{0,}(\\(\\s{0,}\\d{1,}\\s{0,}\\)\\s{0,}|\\d{0,}\\s{0,}-?\\s{0,})\\d{2,}\\s{0,}-?\\s{0,}\\d{2,}\\s{0,}(-?\\s{0,}\\d{2,}|\\s{0,})\\s{0,}$", null, ErrorMessage = "The {0} field contains an invalid telephone number."), DataType(DataType.PhoneNumber)]
        public override string Value
        {
            get;
            set;
        }

        public override ControlResult GetResult()
        {
            if (this.Value == null)
            {
                return null;
            }
            string value = new string(this.Value.Where(new Func<char, bool>(char.IsDigit)).ToArray<char>());
            return new ControlResult(base.FieldItemId, this.Title, value, string.IsNullOrEmpty(this.Value) ? null : string.Join(string.Empty, new string[]
			{
				"<scfriendly>",
				this.Value,
				"</scfriendly>"
			}), false);
        }
    }
}