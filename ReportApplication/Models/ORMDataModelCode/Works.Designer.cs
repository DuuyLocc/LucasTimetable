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

    public partial class Works : XPLiteObject
    {
        int fId;
        [Key(true)]
        public int Id
        {
            get { return fId; }
            set { SetPropertyValue<int>(nameof(Id), ref fId, value); }
        }
        string fName;
        [Size(50)]
        public string Name
        {
            get { return fName; }
            set { SetPropertyValue<string>(nameof(Name), ref fName, value); }
        }
        string fDescription;
        public string Description
        {
            get { return fDescription; }
            set { SetPropertyValue<string>(nameof(Description), ref fDescription, value); }
        }
        int fStatus;
        [ColumnDbDefaultValue("((0))")]
        public int Status
        {
            get { return fStatus; }
            set { SetPropertyValue<int>(nameof(Status), ref fStatus, value); }
        }
        int fPriority;
        [ColumnDbDefaultValue("((1))")]
        public int Priority
        {
            get { return fPriority; }
            set { SetPropertyValue<int>(nameof(Priority), ref fPriority, value); }
        }
        DateTime fDeadline;
        public DateTime Deadline
        {
            get { return fDeadline; }
            set { SetPropertyValue<DateTime>(nameof(Deadline), ref fDeadline, value); }
        }
    }

}