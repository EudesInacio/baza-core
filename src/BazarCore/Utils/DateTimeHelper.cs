using System.Runtime.CompilerServices;

namespace BazarCore.Utils
{
    public static class DateTimeHelper
    {
        public static string FormatDateToHumanReadable(this DateTime date) =>
            date.ToString("ddd, dd/MM/yyyy", new System.Globalization.CultureInfo("pt-PT"));
    }
}
