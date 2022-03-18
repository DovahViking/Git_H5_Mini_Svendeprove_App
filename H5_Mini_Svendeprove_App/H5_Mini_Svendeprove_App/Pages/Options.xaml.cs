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
    public partial class Options : ContentPage
    {
        User user;

        public Options(User user)
        {
            InitializeComponent();

            this.user = user;
            Label_Name.Text = user.name;
            Label_Name.Placeholder = user.name;
        }

        private void on_button_return(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new Home(user));
        }

        private async void on_button_confirm(object sender, EventArgs e)
        {
            if (!Create_User.validate_name(Label_Name.Text)) { return; }

            user.name = Label_Name.Text;

            await update_user(App.path, user);

            App.Current.MainPage = new NavigationPage(new Home(user));
        }

        private async void on_button_delete(object sender, EventArgs e)
        {
            await delete_user(App.path, user.id);

            App.Current.MainPage = new NavigationPage(new Create_User());
        }

        static async Task update_user(string path, User user)
        {
            HttpContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await App.client.PutAsync($"{path}/{user.id}", content);

            await Task.CompletedTask;
        }

        static async Task delete_user(string path, int id)
        {
            HttpResponseMessage response = await App.client.DeleteAsync($"{path}/{id}");

            await Task.CompletedTask;
        }
    }
}