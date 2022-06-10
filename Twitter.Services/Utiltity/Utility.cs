using System.Web;

namespace Twitter.Services.Utilities;
public class Utility
{
    public static string? GetQueryParams(Dictionary<string, string> paramas)
    {
        if (paramas is null || !paramas.Any())
            return null;
        return string.Join("&", paramas.Select(param => $"{param.Key}={param.Value}"));
    }
}
