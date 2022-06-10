namespace Twitter.Services.Constants;
public class UserFields
{
    //Comma-separated list of fields for the user object. Expansion required.
    //Allowed values:
    //created_at,description,entities,id,location,name,pinned_tweet_id,profile_image_url,protected,public_metrics,url,username,verified,withheld
    //Default values:
    //id,name,username

    public const string CreatedAt = "created_at";
    public const string Description = "description";
    public const string Entities = "entities";
    public const string Id = "id";
    public const string Location = "location";
    public const string Name = "name";
    public const string PinnedTweetId = "pinned_tweet_id";
    public const string ProfileImageUrl = "profile_image_url";
    public const string Protected = "protected";
    public const string PublicMetrics = "public_metrics";
    public const string Url = "url";
    public const string Username = "username";
    public const string Verified = "verified";
    public const string Withheld = "withheld";
}
