using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using H5_Mini_Svendeprove_App.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace H5_Mini_Svendeprove_App.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Start : ContentPage
    {
        User user;

        public Start(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void on_button_ok(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new Home(user));
        }
    }
}