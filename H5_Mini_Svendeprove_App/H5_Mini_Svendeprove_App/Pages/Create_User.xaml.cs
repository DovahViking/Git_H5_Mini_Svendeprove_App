using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using H5_Mini_Svendeprove_App.Interfaces;
using System.Net.Http;
using H5_Mini_Svendeprove_App.Models;
using Newtonsoft.Json;
using Device = H5_Mini_Svendeprove_App.Models.Device;
using Xamarin.Essentials;

namespace H5_Mini_Svendeprove_App.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Create_User : ContentPage
    {
        string device_id = DependencyService.Get<IGet_Device_ID>().get_device_id();

        public Create_User()
        {
            InitializeComponent();

            check_for_user(device_id);

            // stay in Create_User until the user has written a valid name and clicked the next button
        }

        private async void check_for_user(string device_id)
        {
            User user = await get_user_from_device_id(App.path, device_id);

            if (user == null) { return; } // if the device_id doesn't exist in the database, do not go to the home page
            else
            {
                App.Current.MainPage = new Home(user); // go to the next page with the existing user
            }
        }

        private async void on_button_continue(object sender, EventArgs e)
        {
            if (!validate_name(username.Text)) { return; } // username is x:name value from xaml

            User user = new User
            {
                name = username.Text,
                date_created = DateTime.UtcNow,
                device = new Device
                {
                    device_id = this.device_id,
                    platform = DeviceInfo.Platform.ToString(),
                    version = DeviceInfo.VersionString,
                    manufacturer = DeviceInfo.Manufacturer
                },
                score = new Score
                {
                    highest_score = 0,
                    recent_score = 0,
                    last_updated = DateTime.UtcNow
                }
            };

            await create_user(App.path, user);

            user = await get_user_from_device_id(App.path, device_id);

            Console.WriteLine($"aaaaaaaaaaaaaaaaaa {user.id}, {user.name}, {user.date_created}, {user.device.device_id}, {user.device.platform}, {user.device.version}, {user.device.manufacturer} aaaaaaaaaaaaaaaaaaa");

            // send post-request to database with new user info...

            App.Current.MainPage = new NavigationPage(new Home(user));
        }

        public static bool validate_name(string name)
        {
            // maybe also check if name already exists?

            string available_chars = " abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";

            if (name != null && name.Length <= 12 && name[0] != ' ' && name[name.Length - 1] != ' ')
            {
                foreach (char username_char in name)
                {
                    int counter = 0;

                    foreach (char available_char in available_chars)
                    {
                        if (username_char == available_char) { break; } // if character in name is valid, break out of the current foreach loop, go to next char in name
                        else if (username_char != available_char && counter == available_chars.Length - 1) { return false; } // if character in name isn't valid, return false

                        counter += 1;
                    }
                }
                return true; // if name is valid
            }
            else { return false; } // if name isn't valid
        }

        static async Task<User> get_user_from_device_id(string path, string device_id)
        {
            User full_user = null;

            HttpResponseMessage response = await App.client.GetAsync($"{path}/user/{device_id}");

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                full_user = JsonConvert.DeserializeObject<User>(content);
            }

            return await Task.FromResult(full_user);
        }

        public async Task<bool> has_user(string full_path)
        {
            User the_user = null; // should maybe be device
            HttpResponseMessage response = await App.client.GetAsync(full_path);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                the_user = JsonConvert.DeserializeObject<User>(content);
            }

            return false;
        }

        static async Task create_user(string path, User user)
        {
            HttpContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await App.client.PostAsync(path, content);

            await Task.CompletedTask;
        }
    }
}