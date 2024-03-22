using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace TestScriptWeb.Models
{
    public class ConvertDateTime
    {
        private DateTime dateTime;
        public ConvertDateTime() { this.dateTime = new DateTime(); }
        public DateTime ConvertToDateTime(string dateString)
        {
            bool success = DateTime.TryParseExact(dateString, "M/d/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime);

            if (success)
            {
                return dateTime;
            }
            else
            {
                return DateTime.MinValue;
            }
        }
    }
}
