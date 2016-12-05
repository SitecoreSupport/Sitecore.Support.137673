using Sitecore.Forms.Mvc.Validators;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Sitecore.Forms.Mvc.ViewModels.Fields;

namespace Sitecore.Support.Forms.Mvc.ViewModels.Fields
{
    public class SingleLineTextField : Sitecore.Support.Forms.Mvc.ViewModels.ValuedFieldViewModel<string>
    {
        [DefaultValue(256)]
        public int MaxLength
        {
            get;
            set;
        }

        [DefaultValue(0)]
        public int MinLength
        {
            get;
            set;
        }

        [DynamicStringLength("MinLength", "MaxLength", ErrorMessage = "The {0} field must be a string with a minimum length of {1} and a maximum length of {2}."), DataType(DataType.Text)]
        public override string Value
        {
            get;
            set;
        }

        public override void Initialize()
        {
            if (this.MaxLength == 0)
            {
                this.MaxLength = 256;
            }
        }
    }
}