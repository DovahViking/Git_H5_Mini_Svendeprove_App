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
    public partial class Leaderboards : ContentPage
    {
        User user;
        List<User> users;

        public Leaderboards(User user)
        {
            InitializeComponent();

            this.user = user;

            //  <StackLayout>
            //    < ListView ItemsSource = "" />
            // </ StackLayout >
        }

        private async void on_button_get_users(object sender, EventArgs e)
        {
            users = await get_users(App.path);

            xml_user_list.ItemsSource = users;
        }

        private void on_button_return(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new Home(user));
        }

        static async Task<List<User>> get_users(string path)
        {
            List<User> users = null;

            HttpResponseMessage response = await App.client.GetAsync($"{path}");

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                users = JsonConvert.DeserializeObject<List<User>>(content);
            }

            return await Task.FromResult(users);
        }
    }
}