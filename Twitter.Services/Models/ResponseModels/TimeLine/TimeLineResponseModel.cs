using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Services.Models.ResponseModels.TimeLine
{

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class ContextAnnotation
    {
        [JsonProperty("domain")]
        public Domain? Domain { get; set; }

        [JsonProperty("entity")]
        public Entity? Entity { get; set; }
    }

    public class Datum
    {
        [JsonProperty("entities")]
        public Entities? Entities { get; set; }

        [JsonProperty("context_annotations")]
        public List<ContextAnnotation>? ContextAnnotations { get; set; }

        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("lang")]
        public string? Lang { get; set; }

        [JsonProperty("text")]
        public string? Text { get; set; }

        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("source")]
        public string? Source { get; set; }

        [JsonProperty("author_id")]
        public string? AuthorId { get; set; }
    }

    public class Domain
    {
        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }
    }

    public class Entities
    {
        [JsonProperty("urls")]
        public List<Url>? Urls { get; set; }

        [JsonProperty("hashtags")]
        public List<Hashtag>? Hashtags { get; set; }

        [JsonProperty("mentions")]
        public List<Mention>? Mentions { get; set; }
    }

    public class Entity
    {
        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }
    }

    public class Hashtag
    {
        [JsonProperty("start")]
        public int? Start { get; set; }

        [JsonProperty("end")]
        public int? End { get; set; }

        [JsonProperty("tag")]
        public string? Tag { get; set; }
    }

    public class Mention
    {
        [JsonProperty("start")]
        public int? Start { get; set; }

        [JsonProperty("end")]
        public int? End { get; set; }

        [JsonProperty("username")]
        public string? Username { get; set; }

        [JsonProperty("id")]
        public string? Id { get; set; }
    }

    public class Meta
    {
        [JsonProperty("next_token")]
        public string? NextToken { get; set; }

        [JsonProperty("result_count")]
        public int? ResultCount { get; set; }

        [JsonProperty("newest_id")]
        public string? NewestId { get; set; }

        [JsonProperty("oldest_id")]
        public string? OldestId { get; set; }
    }

    public class TimeLineResponseModel
    {
        [JsonProperty("data")]
        public List<Datum>? Data { get; set; }

        [JsonProperty("meta")]
        public Meta? Meta { get; set; }
    }

    public class Url
    {
        [JsonProperty("start")]
        public int? Start { get; set; }

        [JsonProperty("end")]
        public int? End { get; set; }

        [JsonProperty("url")]
        public string? Url_ { get; set; }

        [JsonProperty("expanded_url")]
        public string? ExpandedUrl { get; set; }

        [JsonProperty("display_url")]
        public string? DisplayUrl { get; set; }
    }


}
