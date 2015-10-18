using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TravelAPPDataLayer;
using TravelAPPDataLayer.DataObjects;

namespace SampleApp
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Listing lst = new Listing();
            lst.Sleeps = 8;
            //lst.LocationType = "Golf,Beach";
            lst.Amenities = "312,304";

            var t = lst.searchListings("Denmark", "state", "2813", "", "", "");

        }
    }
}