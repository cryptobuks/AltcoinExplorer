namespace AltcoinExplorer.Api.Response
{
    using Newtonsoft.Json;

    public class BaseResponse
    {
        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("hash")]
        public string Hash { get; set; }

        [JsonIgnore]
        public bool Success => string.IsNullOrEmpty(Error);
    }
}