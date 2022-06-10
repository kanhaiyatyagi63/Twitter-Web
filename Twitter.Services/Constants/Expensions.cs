namespace Twitter.Services.Constants;
public class TimeLineExpensions
{

    //Comma-separated list of fields to expand.
    //Default values: none
    public static string AttachmentsPollIds = "attachments.poll_ids";
    public static string AttachmentsMediaKeys = "attachments.media_keys";
    public static string GeoPlaceId = "geo.place_id";
    public static string InReplyToUserId = "in_reply_to_user_id";
    public static string ReferencedTweetsId = "referenced_tweets.id";
    public static string EntitiesMentionsUsername = "entities.mentions.username";
    public static string ReferencedTweetsIdAuthorId = "referenced_tweets.id.author_id";
}

public class UserExpensions
{
    //Expansions enable requests to expand an ID into a full object in the includes response object.
    //Default value: none
    public static string PinnedTweetId = "pinned_tweet_id";
}
