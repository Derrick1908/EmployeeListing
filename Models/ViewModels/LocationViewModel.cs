using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeListing.Models.ViewModels
{
    public class LocationViewModel
    {
        public int id { get; set; }
        public string title { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public int zip { get; set; }
    }
}