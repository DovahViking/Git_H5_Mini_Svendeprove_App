using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using H5_Mini_Svendeprove_App.Interfaces;
using H5_Mini_Svendeprove_App.iOS;

[assembly: Xamarin.Forms.Dependency(typeof(Get_iOS_Device_ID))]
namespace H5_Mini_Svendeprove_App.iOS
{
    internal class Get_iOS_Device_ID : IGet_Device_ID
    {
        string IGet_Device_ID.get_device_id()
        {
            string id = UIDevice.CurrentDevice.IdentifierForVendor.AsString();
            return id;
        }
    }
}