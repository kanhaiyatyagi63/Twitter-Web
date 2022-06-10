namespace Twitter.Services.Models.Core
{
    public class TwitterSettings
    {
        //public TwitterSettings(string clientSecret,
        //                            string clientId,
        //                            string url
        //                            )
        //{

        //    if (string.IsNullOrEmpty(clientSecret))
        //        throw new ArgumentNullException("clientSecret not found");
        //    if (string.IsNullOrEmpty(clientId))
        //        throw new ArgumentNullException("clientId not found");

        //    if (string.IsNullOrEmpty(url))
        //        throw new ArgumentNullException("url not found");

        //    ClientSecret = clientSecret;
        //    ClientId = clientId;
        //    Url = url;
        //}

        public string ClientSecret { get; set; }
        public string ClientId { get; set; }
        public string Url { get; set; }
    }
}
