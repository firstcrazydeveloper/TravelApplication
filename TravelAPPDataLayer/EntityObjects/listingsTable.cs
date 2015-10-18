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
    
    public partial class listingsTable
    {
        public int id { get; set; }
        public string name { get; set; }
        public string continent { get; set; }
        public Nullable<int> country { get; set; }
        public Nullable<int> state { get; set; }
        public Nullable<int> region { get; set; }
        public Nullable<int> city { get; set; }
        public string address { get; set; }
        public string zip { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public Nullable<int> bedrooms { get; set; }
        public Nullable<int> sleeps { get; set; }
        public Nullable<decimal> bathrooms { get; set; }
        public string minStay { get; set; }
        public string propertyType { get; set; }
        public string locationType { get; set; }
        public Nullable<int> entrance { get; set; }
        public string timeZone { get; set; }
        public string description { get; set; }
        public string paymentStatus { get; set; }
        public string coastBeach { get; set; }
        public string golf { get; set; }
        public string specialInterest { get; set; }
        public string howReachThere { get; set; }
        public Nullable<bool> featured { get; set; }
        public Nullable<bool> topTen { get; set; }
        public string metaTitle { get; set; }
        public string metaKeyword { get; set; }
        public string metaDescription { get; set; }
        public bool status { get; set; }
        public System.DateTime date { get; set; }
        public System.DateTime dateUpdate { get; set; }
        public int addedBy { get; set; }
        public string roomDescription { get; set; }
    }
}