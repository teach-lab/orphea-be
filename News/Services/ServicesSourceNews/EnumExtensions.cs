using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace News.Services.ServicesSourceNews;

public static class EnumExtensions
{
    public static string GetDisplayName(this Enum enumValue)
    {
        var attribute = enumValue.GetType()
            .GetField(enumValue.ToString())
            ?.GetCustomAttribute<DisplayAttribute>();

        return attribute?.Name ?? enumValue.ToString();
    }
}