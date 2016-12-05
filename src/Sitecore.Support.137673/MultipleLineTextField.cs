using System;
using System.ComponentModel.DataAnnotations;

namespace Sitecore.Support.Forms.Mvc.ViewModels.Fields
{
    public class MultipleLineTextField : Sitecore.Support.Forms.Mvc.ViewModels.Fields.SingleLineTextField
    {
        [DataType(DataType.MultilineText)]
        public override string Value
        {
            get;
            set;
        }

        public int Rows
        {
            get;
            set;
        }

        public int Columns
        {
            get;
            set;
        }

        public override string ResultParameters
        {
            get
            {
                return "multipleline";
            }
        }

        public MultipleLineTextField()
        {
            this.Rows = 4;
            this.Columns = 1;
        }
    }
}