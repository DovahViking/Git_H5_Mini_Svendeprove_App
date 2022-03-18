using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using H5_Mini_Svendeprove_App.Interfaces;
using H5_Mini_Svendeprove_App.Droid;
using static Android.Provider.Settings;

[assembly: Xamarin.Forms.Dependency(typeof(Get_Android_Device_ID))]
namespace H5_Mini_Svendeprove_App.Droid
{
    public class Get_Android_Device_ID : IGet_Device_ID
    {
        string IGet_Device_ID.get_device_id()
        {
            var context = Android.App.Application.Context;
            string id = Android.Provider.Settings.Secure.GetString(context.ContentResolver, Secure.AndroidId);
            return id;
        }
    }
}