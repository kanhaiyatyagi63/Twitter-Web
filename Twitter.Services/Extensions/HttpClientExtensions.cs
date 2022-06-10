using Newtonsoft.Json;
using System.Text;
using Twitter.Services.Models.ResponseModels.Authentication;

namespace Twitter.Services.Extensions;
public static class HttpClientExtensions
{
    internal static async Task<TResponseData?> ParseResponseData<TResponseData>(this HttpResponseMessage response)
       where TResponseData : class, new()
    {
        if (response == null) return null;
        if (!response.IsSuccessStatusCode) return null;

        var responseJson = await response.Content.ReadAsStringAsync();
        if (string.IsNullOrWhiteSpace(responseJson) && typeof(TResponseData) != typeof(EmptyResponse)) return null;

        return JsonConvert.DeserializeObject<TResponseData>(responseJson);
    }

    internal static StringContent? SerializeRequestData<TRequestData>(this TRequestData data)
    {
        var jsonPayload = data != null ? JsonConvert.SerializeObject(data) : "";

        return new StringContent(jsonPayload, Encoding.UTF8, "application/json");
    }

    internal static async Task<TResponseData?> GetJsonAsync<TResponseData>(this HttpClient client, string url)
        where TResponseData : class, new()
    {
        var httpResponse = await client.GetAsync(url);

        return await httpResponse.ParseResponseData<TResponseData>();
    }

    internal static async Task<TResponseData?> PostJsonAsync<TRequestData, TResponseData>(this HttpClient client, string url, TRequestData data)
        where TRequestData : class, new()
        where TResponseData : class, new()
    {
        var json = data.SerializeRequestData();
        var response = await client.PostAsync(url, json);

        return await response.ParseResponseData<TResponseData>();
    }

    internal static async Task<TResponseData?> PostJsonAsync<TResponseData>(this HttpClient client, string url)
        where TResponseData : class, new()
    {
        var response = await client.PostAsync(url, null);

        return await response.ParseResponseData<TResponseData>();
    }

    internal static async Task<TResponseData?> PatchJsonAsync<TRequestData, TResponseData>(this HttpClient client, string url, TRequestData data)
        where TRequestData : class, new()
        where TResponseData : class, new()
    {
        var json = data.SerializeRequestData();
        var response = await client.PatchAsync(url, json);

        return await response.ParseResponseData<TResponseData>();
    }

    internal static async Task<TResponseData?> DeleteJsonAsync<TResponseData>(this HttpClient client, string url)
        where TResponseData : class, new()
    {
        var response = await client.DeleteAsync(url);

        return await response.ParseResponseData<TResponseData>();
    }
}
