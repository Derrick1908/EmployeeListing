using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeListing.Models.ViewModels
{
    public class JobViewModel
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int locationId { get; set; }
        public LocationViewModel location { get; set; }
        public int departmentId { get; set; }
        public DepartmentViewModel department { get; set; }
        public DateTime postedDate { get; set; }
        public DateTime closingDate { get; set; }
        
    }

    public class ListRequest
    {
        public string q { get; set; }
        public int pageNo { get; set; }
        public int pageSize { get; set; }
        public int? locationId { get; set; }
        public int? departmentId { get; set; }
    }

    public class ListResponse
    {
        public int total { get; set; }
        
        public List<JobViewModel> data;

    }
}