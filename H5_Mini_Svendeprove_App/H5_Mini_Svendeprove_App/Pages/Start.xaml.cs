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
    public partial class Start : ContentPage
    {
        public Start(User user)
        {
            InitializeComponent();
        }
    }
}