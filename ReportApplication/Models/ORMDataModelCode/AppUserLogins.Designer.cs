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

    public partial class AppUserLogins : XPLiteObject
    {
        Guid fUserId;
        [Key(true)]
        public Guid UserId
        {
            get { return fUserId; }
            set { SetPropertyValue<Guid>(nameof(UserId), ref fUserId, value); }
        }
        string fLoginProvider;
        [Size(SizeAttribute.Unlimited)]
        public string LoginProvider
        {
            get { return fLoginProvider; }
            set { SetPropertyValue<string>(nameof(LoginProvider), ref fLoginProvider, value); }
        }
        string fProviderKey;
        [Size(SizeAttribute.Unlimited)]
        public string ProviderKey
        {
            get { return fProviderKey; }
            set { SetPropertyValue<string>(nameof(ProviderKey), ref fProviderKey, value); }
        }
        string fProviderDisplayName;
        [Size(SizeAttribute.Unlimited)]
        public string ProviderDisplayName
        {
            get { return fProviderDisplayName; }
            set { SetPropertyValue<string>(nameof(ProviderDisplayName), ref fProviderDisplayName, value); }
        }
    }

}