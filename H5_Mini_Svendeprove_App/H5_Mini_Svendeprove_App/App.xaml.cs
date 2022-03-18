using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using H5_Mini_Svendeprove_App.Pages;
using System.Net.Http;

namespace H5_Mini_Svendeprove_App
{
    public partial class App : Application
    {
        public static HttpClient client = new HttpClient();
        public static string path = "https://192.168.10.245:6969/api/User_";

        public App()
        {
            InitializeComponent();

            HttpClientHandler http_client_handler = new HttpClientHandler();
            http_client_handler.ServerCertificateCustomValidationCallback =
            (message, cert, chain, errors) => { return true; }; // this is done to bypass any certificate issue that might appear, when connecting to the web-API

            client = new HttpClient(http_client_handler);

            MainPage = new NavigationPage(new Create_User());
        }

        protected override void OnStart()
        {

        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
