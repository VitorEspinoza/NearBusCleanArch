using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace NearBusCleanArch.Infra.Data.Converters;

public class DayOfWeekArrayConverter : ValueConverter<DayOfWeek[], string>
{
    public DayOfWeekArrayConverter() : base(
        v => ConvertToString(v),
        v => ConvertFromString(v)
    )
    { }
    
    private static DayOfWeek[] ConvertFromString(string value)
    {
        return value.Split(',').Select(s => (DayOfWeek)int.Parse(s)).ToArray();
    }

    private static string ConvertToString(DayOfWeek[] value)
    {
        return string.Join(",", value.Select(d => (int)d));
    }

}