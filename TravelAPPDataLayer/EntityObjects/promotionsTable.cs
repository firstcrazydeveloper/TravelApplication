//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TravelAPPDataLayer.EntityObjects
{
    using System;
    using System.Collections.Generic;
    
    public partial class promotionsTable
    {
        public int id { get; set; }
        public Nullable<int> planID { get; set; }
        public string code { get; set; }
        public Nullable<int> discount { get; set; }
        public Nullable<int> months { get; set; }
        public Nullable<double> amount { get; set; }
        public Nullable<System.DateTime> startDate { get; set; }
        public Nullable<System.DateTime> endDate { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public Nullable<bool> status { get; set; }
    }
}
