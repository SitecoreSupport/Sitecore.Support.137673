﻿using Sitecore.Forms.Mvc.TypeConverters;
using Sitecore.WFFM.Abstractions.Actions;
using System;
using System.ComponentModel;
using System.Globalization;

namespace Sitecore.Support.Forms.Mvc.ViewModels.Fields
{
    public class DatePickerField : Sitecore.Support.Forms.Mvc.ViewModels.ValuedFieldViewModel<string>
    {
        public override string Value
        {
            get
            {
                return base.Value;
            }
            set
            {
                base.Value = (Sitecore.DateUtil.IsIsoDate(value) ? Sitecore.DateUtil.IsoDateToDateTime(value).ToString(this.DateFormat ?? "yy-MM-dd") : value);
            }
        }

        public string DateFormat
        {
            get;
            set;
        }

        [TypeConverter(typeof(IsoDateTimeConverter))]
        public DateTime StartDate
        {
            get;
            set;
        }

        [TypeConverter(typeof(IsoDateTimeConverter))]
        public DateTime EndDate
        {
            get;
            set;
        }

        public DatePickerField()
        {
            this.DateFormat = "yy-MM-dd";
            this.StartDate = Sitecore.DateUtil.IsoDateToDateTime("20000101T120000");
            this.EndDate = DateTime.Now.AddYears(1).Date;
        }

        public override void Initialize()
        {
            if (string.IsNullOrEmpty(this.Value))
            {
                this.Value = DateTime.Now.ToString(this.DateFormat);
            }
        }

        public override ControlResult GetResult()
        {
            return new ControlResult(base.FieldItemId, this.Title, Sitecore.DateUtil.ToIsoDate(DateTime.ParseExact(this.Value, this.DateFormat, DateTimeFormatInfo.InvariantInfo)), this.ResultParameters, false);
        }
    }
}