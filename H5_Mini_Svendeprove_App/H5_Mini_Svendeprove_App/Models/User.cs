using System;
using System.Collections.Generic;
using System.Text;

namespace H5_Mini_Svendeprove_App.Models
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime date_created { get; set; }
        public Device device { get; set; }
        public Score score { get; set; }
    }
}
