using System.Globalization;
using System.Web;

namespace Twitter.Services.Utilities;
public static class Utility
{
    public static string? GetQueryParams(Dictionary<string, string> paramas)
    {
        if (paramas is null || !paramas.Any())
            return null;
        return string.Join("&", paramas.Select(param => $"{param.Key}={param.Value}"));
    }
    public static string ToRfc3339String(this DateTime dateTime)
    {
        return dateTime.ToString("yyyy-MM-dd'T'HH:mm:ss'Z'");
    }
}
