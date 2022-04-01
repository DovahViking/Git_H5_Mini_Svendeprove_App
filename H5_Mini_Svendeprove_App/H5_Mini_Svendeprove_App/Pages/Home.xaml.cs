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
    public partial class Home : ContentPage
    {
        User user;

        public Home(User user)
        {
            InitializeComponent();

            this.user = user;
            Label_User.Text = user.name;
        }

        private async void on_button_start(object sender, EventArgs e)
        {
            await post_start_game_notification(App.path, user);
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

        static async Task post_start_game_notification(string path, User user)
        {
            HttpContent content = new StringContent(JsonConvert.SerializeObject(user.id), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await App.client.PostAsync($"{path}/user/game/{user.id}", content);

            await Task.CompletedTask;
        }
    }
}