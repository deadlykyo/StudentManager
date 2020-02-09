using StudentModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProcessor.Tools
{
    public class FieldParser
    {
        public static DateTime ConvertToDate(string field)
        {
            try
            {
                var result = DateTime.ParseExact(field, Constants.DateFormat, System.Globalization.CultureInfo.InvariantCulture);

                return result;
            }
            catch (Exception ex)
            {
                throw new FormatException("ConvertToDate:" + ex.Message + ex.StackTrace);
            }

        }
    }
}
