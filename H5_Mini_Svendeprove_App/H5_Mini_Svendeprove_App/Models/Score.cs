using System;
using System.Collections.Generic;
using System.Text;

namespace H5_Mini_Svendeprove_App.Models
{
    public class Score
    {
        public int id { get; set; }
        public int highest_score { get; set; }
        public int recent_score { get; set; }
        public DateTime last_updated { get; set; }
    }
}
