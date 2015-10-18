using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAPPDataLayer.Utility
{
    public static class Helper
    {
        public static int? ParseNInt(string val)
        {
            int i;
            return int.TryParse(val, out i) ? (int?)i : null;
        }
    }
}
