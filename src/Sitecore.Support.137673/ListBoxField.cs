using Sitecore.Forms.Core.Data;
using Sitecore.WFFM.Abstractions.Dependencies;
using Sitecore.WFFM.Abstractions.Shared;
using System;
using System.ComponentModel;

namespace Sitecore.Support.Forms.Mvc.ViewModels.Fields
{
    public class ListBoxField : Sitecore.Support.Forms.Mvc.ViewModels.Fields.CheckboxListField
    {
        [DefaultValue(4)]
        public int Rows
        {
            get;
            set;
        }

        public string SelectionMode
        {
            get;
            set;
        }

        public ListBoxField()
            : this(new ListFieldValueFormatter(DependenciesManager.Resolve<ISettings>()))
        {
        }

        public ListBoxField(ListFieldValueFormatter listFieldValueFormatter)
            : base(listFieldValueFormatter)
        {
            this.SelectionMode = "Single";
            this.Rows = 4;
        }
    }
}