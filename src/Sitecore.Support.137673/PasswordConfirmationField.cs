using Sitecore.Forms.Mvc.Validators;
using System;
using System.ComponentModel.DataAnnotations;

namespace Sitecore.Support.Forms.Mvc.ViewModels.Fields
{
    public class PasswordConfirmationField : Sitecore.Support.Forms.Mvc.ViewModels.Fields.PasswordField
    {
        [DynamicCompare("Value", "PasswordTitle", "ConfirmationTitle", ErrorMessage = "The {0} and {1} fields must be the same."), DataType(DataType.Password)]
        public string Confirmation
        {
            get;
            set;
        }

        public string ConfirmationHelp
        {
            get;
            set;
        }

        public string PasswordHelp
        {
            get;
            set;
        }

        public string PasswordTitle
        {
            get;
            set;
        }

        public string ConfirmationTitle
        {
            get;
            set;
        }

        public PasswordConfirmationField()
        {
            this.PasswordTitle = "Password";
            this.ConfirmationTitle = "Confirmation";
        }
    }
}