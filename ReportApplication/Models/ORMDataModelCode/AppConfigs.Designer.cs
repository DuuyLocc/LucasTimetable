﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
namespace ReportApplication.Models.Timetable
{

    public partial class AppConfigs : XPLiteObject
    {
        string fKey;
        [Key]
        [Size(450)]
        public string Key
        {
            get { return fKey; }
            set { SetPropertyValue<string>(nameof(Key), ref fKey, value); }
        }
        string fValue;
        [Size(SizeAttribute.Unlimited)]
        public string Value
        {
            get { return fValue; }
            set { SetPropertyValue<string>(nameof(Value), ref fValue, value); }
        }
    }

}
