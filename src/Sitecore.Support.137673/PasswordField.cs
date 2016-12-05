using Sitecore.WFFM.Abstractions.Actions;
using System;
using System.ComponentModel.DataAnnotations;

namespace Sitecore.Support.Forms.Mvc.ViewModels.Fields
{
    public class PasswordField : Sitecore.Support.Forms.Mvc.ViewModels.Fields.SingleLineTextField
    {
        [DataType(DataType.Password)]
        public override string Value
        {
            get;
            set;
        }

        public override ControlResult GetResult()
        {
            return new ControlResult(base.FieldItemId, this.Title, this.Value, null, true);
        }

        public override void SetValueFromQuery(string valueFromQuery)
        {
        }
    }
}