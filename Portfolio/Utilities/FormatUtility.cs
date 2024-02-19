namespace Portfolio.Utilities
{
    public class FormatUtility
    {
        public static string FormatYear(string year)
        {
            int number;

            if (int.TryParse(year, out number))
            {
                string formattedNumber = number.ToString("0000");
                return formattedNumber;
            }
            else
            {
                return "";
            }
        }

        public static string FormatMonthAndDay(string day)
        {
            int number;

            if (int.TryParse(day, out number))
            {
                string formattedNumber = number.ToString("00");
                return formattedNumber;
            }
            else
            {
                return "";
            }
        }
    }
}
