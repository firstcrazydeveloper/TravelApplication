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
    
    public partial class ratesDataTable
    {
        public int id { get; set; }
        public string name { get; set; }
        public Nullable<System.DateTime> beginDate { get; set; }
        public Nullable<System.DateTime> endDate { get; set; }
        public Nullable<double> weekNight { get; set; }
        public Nullable<double> weekendNight { get; set; }
        public Nullable<double> weekly { get; set; }
        public Nullable<double> monthly { get; set; }
        public int listingID { get; set; }
        public double weekNightTemp { get; set; }
        public double weekendNightTemp { get; set; }
        public double weeklyTemp { get; set; }
        public double monthlyTemp { get; set; }
    }
}
