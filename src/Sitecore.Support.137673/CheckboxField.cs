using Sitecore.Forms.Mvc.Extensions;
using System;

namespace Sitecore.Support.Forms.Mvc.ViewModels.Fields
{
    public class CheckboxField : Sitecore.Support.Forms.Mvc.ViewModels.ValuedFieldViewModel<bool>
    {
        public override bool Value
        {
            get;
            set;
        }

        public override void Initialize()
        {
            base.ShowTitle = false;
            string value = base.Parameters.GetValue("checked");
            this.Value = (value != null && value.ToLower() == "yes");
        }

        public override void SetValueFromQuery(string valueFromQuery)
        {
            this.Value = Sitecore.MainUtil.GetBool(valueFromQuery, false);
        }
    }
}