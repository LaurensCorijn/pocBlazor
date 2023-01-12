namespace poc_blazor.Infrastructure
{
    public class PublicClient
    {
        public HttpClient Client { get; set; }

        public PublicClient(HttpClient httpClient)
        {
            Client = httpClient;
        }
    }
}
