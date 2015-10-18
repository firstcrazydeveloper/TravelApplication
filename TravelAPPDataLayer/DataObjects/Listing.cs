using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAPPDataLayer.EntityObjects;
using TravelAPPDataLayer.Utility;

namespace TravelAPPDataLayer.DataObjects
{
    public class Listing
    {
        RentalHolidayEntities DbObj;
        public Listing()
        {
            DbObj = new RentalHolidayEntities();
        }

        public IQueryable<listingsTable> searchListings(string keyword, string type, string typeID, string dateIn, string dateOut, string guestsSize)
        {
            //select listingsTable.id, listingsTable.name, listingsTable.bathrooms, listingsTable.bedrooms, listingsTable.sleeps, listingsTable.minStay, listingsTable.propertyType, listingsTable.latitude, listingsTable.longitude, countriesTable.name as country, statesTable.name as state, regionsTable.name as region, citiesTable.name as city from listingsTable, countriesTable, statesTable, regionsTable, citiesTable where countriesTable.id = listingsTable.country and listingsTable.state = statesTable.id and listingsTable.region = regionsTable.id and citiesTable.id = listingsTable.city " + strCmdAdd + keywordText + filter + " and status='True' order by name

            IQueryable<listingsTable> listingTableObj = DbObj.listingsTables;


           // var listingTableObjtemp = from lt in DbObj.listingsTables join ct in DbObj.countriesTables on lt.country equals ct.id where ct.id == 1 select new { ct.name, lt };

            if (type == "country")
            {
                int? te=Helper.ParseNInt(typeID);
                listingTableObj = listingTableObj.Where(lt => lt.country == te);
                //strCmdAdd = " and listingsTable.country=" + typeID;
            }
            else if (type == "state")
            {
                int? te = Helper.ParseNInt(typeID);
                listingTableObj = listingTableObj.Where(lt => lt.state == te);
                //strCmdAdd = " and statesTable.id=" + typeID;
            }
            else if (type == "region")
            {
                int? te = Helper.ParseNInt(typeID);
                listingTableObj = listingTableObj.Where(lt => lt.region == te);
                //strCmdAdd = " and regionsTable.id=" + typeID;
            }
            else if (type == "city")
            {
                int? te = Helper.ParseNInt(typeID);
                listingTableObj = listingTableObj.Where(lt => lt.city == te);
                //strCmdAdd = " and citiesTable.id=" + typeID;
            }
            else if (type == "listing")
            {
                int? te = Helper.ParseNInt(typeID);
                listingTableObj = listingTableObj.Where(lt => lt.id == te);
                //strCmdAdd = " and listingsTable.id=" + typeID;
            }
            else if (type == "featured")
            {
                listingTableObj = listingTableObj.Where(lt => lt.featured == true);
                //strCmdAdd = " and listingsTable.featured='1'";
            }

            if (Sleeps != 0)
            {
                listingTableObj = listingTableObj.Where(lt => lt.sleeps >= Sleeps);
                //filter += " and listingsTable.sleeps>=" + HttpUtility.HtmlEncode(sleeps.ToString());
            }

            if (Bathrooms != 0)
            {
                listingTableObj = listingTableObj.Where(lt => lt.bathrooms >= Bathrooms);
                //filter += " and listingsTable.bathrooms>=" + HttpUtility.HtmlEncode(bathrooms.ToString());
            }

            if (Bedrooms != 0)
            {
                listingTableObj = listingTableObj.Where(lt => lt.bedrooms >= Bedrooms);
                //filter += " and listingsTable.bedrooms>=" + HttpUtility.HtmlEncode(bedrooms.ToString());
            }

            if (!String.IsNullOrEmpty(PropertyType))
            {
                listingTableObj = listingTableObj.Where(lt => lt.propertyType == PropertyType);
                //if (propertyType != "")
                //{
                //    filter += " and listingsTable.propertyType='" + HttpUtility.HtmlEncode(propertyType) + "'";
                //}
            }


            if (!String.IsNullOrEmpty(LocationType))
            {
                string[] locations = LocationType.Split(',');
                for (int i = 0; i < locations.Length; i++)
                {
                    var tmp = locations[i];
                    listingTableObj = listingTableObj.Where(lt => lt.locationType.ToLower().Contains(tmp.ToLower()));
                    //filter += " and listingsTable.locationType like '%" + HttpUtility.HtmlEncode(locations[i]) + "%'";
                }
                //if (locationType != "")
                //{
                //    string[] locations = locationType.Split(',');
                //    for (int i = 0; i < locations.Length; i++)
                //    {
                //        filter += " and listingsTable.locationType like '%" + HttpUtility.HtmlEncode(locations[i]) + "%'";
                //    }
                //}
            }

            if (!String.IsNullOrEmpty(Amenities))
            {
                var temp = searchAmenities(Amenities);
                listingTableObj = listingTableObj.Where(lt => temp.Contains(lt.id));
                
            }

            if (!String.IsNullOrEmpty(Availbility))
            {
                var temp = listingsAvailable(dateIn,dateOut);
                listingTableObj = listingTableObj.Where(lt => !temp.Contains(lt.id));
               
            }
            if (keyword != "")
            {
                var temp = searchCountry(keyword);
                listingTableObj = listingTableObj.Where(lt => temp.Contains(lt.country));
                //keywordText = "and (countriesTable.name like '%" + keyword + "%' or statesTable.name like '%" + keyword + "%' or regionsTable.name like '%" + keyword + "%' or citiesTable.name like '%" + keyword + "%')";
                //keywordText = "and (countriesTable.name like '%" + HttpUtility.HtmlEncode(keyword) + "%' )";
            }
            var t = listingTableObj.ToList();

            return listingTableObj;
        }

        public List<int> searchAmenities(string search)
        {
            string[] amenitiesArr = search.Split(',');
            IEnumerable<amenitiesTable> amt = DbObj.amenitiesTables;

            for (int i = 0; i < amenitiesArr.Length; i++)
            {
                var temp = amenitiesArr[i];
                amt = amt.Where(am => am.amenities!=null && am.amenities.Contains(temp));
            }

            List<int>  amtdata = amt.Select(am => am.listingID).ToList();
            return amtdata;
        }

        public List<int> listingsAvailable(string dateIn, string dateOut)
        {
            IEnumerable<availabilityTable> at = DbObj.availabilityTables;
            DateTime thisDateIn;
            DateTime thisDateOut;
            DateTime.TryParse(dateIn, out thisDateIn);
            DateTime.TryParse(dateOut, out thisDateOut);

            at = at.Where(a => a.date > thisDateIn && a.date < thisDateOut);
            List<int> atData = at.Select(a => a.listingID).ToList();
            return atData;
        }
        public List<int?> searchCountry(string search)
        {
           
            IEnumerable<countriesTable> country = DbObj.countriesTables.Where(ct=>ct.name.ToLower().Contains(search.ToLower()));


            List<int?> countrydata = country.Select(ct => Helper.ParseNInt(ct.id.ToString())).ToList();
            return countrydata;
        }

        public List<int> searchRate(string Type,string PriceUpper,string PriceLower)
        {
            double? lowertemp=(double?)Convert.ToDouble( PriceLower);
            double? Uppertemp=(double?)Convert.ToDouble( PriceUpper);
            var rateTable = DbObj.ratesDataTables.Join(DbObj.listingsTables, rt => rt.listingID, lt => lt.id, (rt, lt) => new {lt.minStay,rt.weekNight, rt.monthly,rt.beginDate,rt.endDate,rt.listingID,lt.id});
            if (Type == "day")
            {
                if (int.Parse(PriceLower) == 0)
                {
                    rateTable = rateTable.Where(rt => rt.listingID==rt.id || rt.minStay.ToLower().Contains("night") && rt.weekNight >= lowertemp && rt.weekNight <= Uppertemp && rt.beginDate.Value.Month <= DateTime.Now.Month && rt.endDate.Value.Month >= DateTime.Now.Month && rt.beginDate.Value.Date <= DateTime.Now.Date && rt.endDate.Value.Date >= DateTime.Now.Date);
                }
                else
                {
                    rateTable = rateTable.Where(rt => rt.listingID == rt.id && rt.minStay.ToLower().Contains("night") && rt.weekNight >= lowertemp && rt.weekNight <= Uppertemp && rt.beginDate.Value.Month <= DateTime.Now.Month && rt.endDate.Value.Month >= DateTime.Now.Month && rt.beginDate.Value.Date <= DateTime.Now.Date && rt.endDate.Value.Date >= DateTime.Now.Date);

                }
            }
            if (Type == "week")
            {
            }
            if (Type == "month")
            {
            }
        }
        public int Sleeps { get; set; }

        public int Bathrooms { get; set; }

        public int Bedrooms { get; set; }

        public string PropertyType { get; set; }

        public string LocationType { get; set; }

        public string Amenities { get; set; }

        public string Availbility { get; set; }
    }
}
