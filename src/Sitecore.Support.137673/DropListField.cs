using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Sitecore.Support.Forms.Mvc.ViewModels.Fields
{
    public class DropListField : Sitecore.Support.Forms.Mvc.ViewModels.Fields.RadioListField
    {
        public bool EmptyChoise
        {
            get;
            set;
        }

        public DropListField()
        {
            this.EmptyChoise = true;
        }

        public override void Initialize()
        {
            if (base.Parameters.ContainsKey("emptychoice"))
            {
                string a = base.Parameters["emptychoice"];
                this.EmptyChoise = (a == "yes");
            }
            if (base.Items == null)
            {
                base.Items = new List<SelectListItem>();
            }
            if (this.EmptyChoise)
            {
                base.Items.Insert(0, new SelectListItem
                {
                    Text = string.Empty,
                    Value = string.Empty
                });
            }
            base.Initialize();
        }
    }
}