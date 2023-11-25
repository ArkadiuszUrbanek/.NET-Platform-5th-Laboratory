using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Globalization;

namespace Lab5.ValueConverters
{
    public class DateOnlyToStringConverter : ValueConverter<DateOnly, string>
    {
        public DateOnlyToStringConverter() : base(dateOnly => dateOnly.ToString("yyyy-MM-dd"), dateString => DateOnly.ParseExact(dateString, "yyyy-MM-dd")) 
        {
        }
    }
}
