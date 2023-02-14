using AngleSharp.Dom;
using System.Globalization;

namespace Infrastructure.Parser
{
    /// <summary>
    /// класс для проверки даты комментария
    /// </summary>
    public static class CheckDate
    {
        public static DateTime? Check(IElement date)
        {
            if (date.TextContent.Contains("202"))
                return null;

            if (date.TextContent.Contains("сегодня"))
            {
                string hoursAndMinutes = date.TextContent.Substring(10);
                DateTime parseDate = DateTime.ParseExact(hoursAndMinutes, "H:mm", new CultureInfo("ru-RU"));
                return parseDate;
            }
            else if (date.TextContent.Contains("вчера"))
            {
                string hoursAndMinutes = date.TextContent.Substring(8);
                DateTime parseDate = DateTime.ParseExact(hoursAndMinutes, "H:mm", new CultureInfo("ru-RU")).AddDays(-1);
                return parseDate;
            }
            else
            {
                int index = date.TextContent.LastIndexOf('в') - 1;
                string tempDate = date.TextContent.Substring(0, index) + "." + $" {date.TextContent.Substring(index + 3)}";
                DateTime parseDate = DateTime.ParseExact(tempDate, "d MMM H:mm", new CultureInfo("ru-RU"));
                return parseDate;
            }
        }
    }
}
