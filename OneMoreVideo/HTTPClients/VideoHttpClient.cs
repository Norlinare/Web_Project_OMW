namespace OMV.Common.HTTPClients
{
    public class VideoHttpClient
    {
        public HttpClient Client { get; }

        public VideoHttpClient(HttpClient httpClient)
        {
            Client = httpClient;
        }
    }
}
