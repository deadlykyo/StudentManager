using StudentModel.Entity;
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

        public static Gender ConvertToGender(string input)
        {
            try
            {
                Gender gender;
                Enum.TryParse(input, true, out gender);
                return gender;
            }
            catch (Exception ex)
            {
                throw new FormatException("ConvertToGender:" + ex.Message + ex.StackTrace);
            }
        }

        public static Stage ConvertToStage(string input)
        {
            try
            {
                Stage stage;
                Enum.TryParse(input, out stage);
                return stage;
            }
            catch (Exception ex)
            {
                throw new FormatException("ConvertToStage:" + ex.Message + ex.StackTrace);
            }
        }
    }
}
