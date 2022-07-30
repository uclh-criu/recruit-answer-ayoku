namespace NIHR.UCLH.Research.Web.Security
{

    public interface IIdentityServerClient
    {        
        string BaseAddress { get; }
    }
    public class IdentityServer : IIdentityServerClient
    {
        private readonly HttpClient _httpClient;

        public IdentityServer(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public string BaseAddress
        {
            get { return _httpClient.BaseAddress.AbsoluteUri; }
        }

    }
}
