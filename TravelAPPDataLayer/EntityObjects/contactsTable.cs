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
    
    public partial class contactsTable
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string image { get; set; }
        public bool imageShow { get; set; }
        public string address { get; set; }
        public string zip { get; set; }
        public string continent { get; set; }
        public Nullable<int> country { get; set; }
        public Nullable<int> state { get; set; }
        public Nullable<int> region { get; set; }
        public Nullable<int> city { get; set; }
        public string primaryPhone { get; set; }
        public string alternatePhone { get; set; }
        public string callTime { get; set; }
        public string fax { get; set; }
        public string timeZone { get; set; }
        public string language { get; set; }
        public string aboutMe { get; set; }
        public int ownerID { get; set; }
        public bool status { get; set; }
        public Nullable<int> profileCount { get; set; }
    }
}
