using System;
using System.Globalization;

namespace BusinessAccessLayer.BO
{
    public class CommonMethodBO
    {
        public static DateTime GetDateFormat(string dateString)
        {
            IFormatProvider culture = new CultureInfo("fr-Fr", true);
            DateTime dt = DateTime.ParseExact(dateString, "dd-MM-yyyy", culture, DateTimeStyles.NoCurrentDateDefault);
            return dt;
        }
    }
}
