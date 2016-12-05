using Sitecore.Form.Core.Utility;
using Sitecore.Forms.Mvc.Attributes;
using Sitecore.Forms.Mvc.Interfaces;
using Sitecore.Forms.Mvc.TypeConverters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web.Mvc;

namespace Sitecore.Support.Forms.Mvc.ViewModels.Fields
{
    public class RadioListField : Sitecore.Support.Forms.Mvc.ViewModels.ValuedFieldViewModel<string>, ISelectList
    {
        public override string ResultParameters
        {
            get
            {
                if (this.Items != null)
                {
                    SelectListItem selectListItem = this.Items.SingleOrDefault((SelectListItem x) => x.Selected);
                    if (selectListItem != null)
                    {
                        return selectListItem.Text;
                    }
                }
                return string.Empty;
            }
        }

        [TypeConverter(typeof(ListSelectItemsConverter))]
        public List<SelectListItem> Items
        {
            get;
            set;
        }

        [ParameterName("selectedvalue")]
        public override string Value
        {
            get;
            set;
        }

        public RadioListField()
        {
            this.Items = new List<SelectListItem>();
        }

        public override void Initialize()
        {
            if (this.Items == null)
            {
                this.Items = new List<SelectListItem>();
            }
            if (!string.IsNullOrEmpty(this.Value))
            {
                this.Value = string.Join(",", ParametersUtil.XmlToStringArray(this.Value));
            }
        }
    }
}