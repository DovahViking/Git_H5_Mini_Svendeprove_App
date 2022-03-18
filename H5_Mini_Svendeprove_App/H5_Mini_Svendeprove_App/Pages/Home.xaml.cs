using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using H5_Mini_Svendeprove_App.Models;

namespace H5_Mini_Svendeprove_App.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        User user;

        public Home(User user)
        {
            InitializeComponent();

            this.user = user;
            Label_User.Text = user.name;
        }

        private void on_button_start(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new Start(user));
        }
        private void on_button_leaderboards(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new Leaderboards(user));
        }
        private void on_button_options(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new Options(user));
        }
    }
}