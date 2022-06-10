using Newtonsoft.Json;

namespace Twitter.Services.Models.ResponseModels.Users;
public class Data
{
    [JsonProperty("protected")]
    public bool Protected { get; set; }

    [JsonProperty("id")]
    public string? Id { get; set; }

    [JsonProperty("description")]
    public string? Description { get; set; }

    [JsonProperty("name")]
    public string? Name { get; set; }

    [JsonProperty("url")]
    public string? Url { get; set; }

    [JsonProperty("verified")]
    public bool Verified { get; set; }

    [JsonProperty("location")]
    public string? Location { get; set; }

    [JsonProperty("public_metrics")]
    public PublicMetrics? PublicMetrics { get; set; }

    [JsonProperty("profile_image_url")]
    public string? ProfileImageUrl { get; set; }

    [JsonProperty("entities")]
    public Entities? Entities { get; set; }

    [JsonProperty("created_at")]
    public DateTime? CreatedAt { get; set; }

    [JsonProperty("username")]
    public string? Username { get; set; }
}

public class Description
{
    [JsonProperty("hashtags")]
    public List<Hashtag> Hashtags { get; set; }
}

public class Entities
{
    [JsonProperty("description")]
    public Description Description { get; set; }
}

public class Hashtag
{
    [JsonProperty("start")]
    public int Start { get; set; }

    [JsonProperty("end")]
    public int End { get; set; }

    [JsonProperty("tag")]
    public string Tag { get; set; }
}

public class PublicMetrics
{
    [JsonProperty("followers_count")]
    public int FollowersCount { get; set; }

    [JsonProperty("following_count")]
    public int FollowingCount { get; set; }

    [JsonProperty("tweet_count")]
    public int TweetCount { get; set; }

    [JsonProperty("listed_count")]
    public int ListedCount { get; set; }
}

public class UserResponseModel
{
    [JsonProperty("data")]
    public Data? Data { get; set; }
}
