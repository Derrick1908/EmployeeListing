//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EmployeeListing.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class JOB
    {
        public int JOBID { get; set; }
        public string JOBTITLE { get; set; }
        public string JOBDESCRIPTION { get; set; }
        public int LOCATIONID { get; set; }
        public int DEPARTMENTID { get; set; }
        public System.DateTime CLOSINGDATE { get; set; }
    
        public virtual DEPARTMENT DEPARTMENT { get; set; }
        public virtual LOCATION LOCATION { get; set; }
    }
}