

using Newtonsoft.Json;

namespace NIHR.UCLH.Research.Web.Services.Implementations
{
    public class RequestService : IRequestService
    {
        //private readonly IIdentityServerClient _identityServer;
        private readonly IConfiguration _configuration;
        public RequestService(/*IIdentityServerClient identityServer ,*/ IConfiguration configuration)
        {
                //this._identityServer = identityServer;
            this._configuration = configuration;
        }
        public async Task<IList<AgeModel>> GetAdmissionByAge(int age)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7011/");
                var response = await client.GetAsync(String.Concat("Admission/age?age=", age.ToString()));
                string jsonString = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<List<AgeModel>>(jsonString);
                }
                else
                {
                    //  _logger.LogError(jsonString);
                }

                return null;
            }

        }
        public async Task<IList<EthincityModel>> GetAdmissionByEthinicity(string region)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7011/");
                var response = await client.GetAsync(String.Concat("Admission/ethincity?origin=", region.ToString()));
                string jsonString = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<List<EthincityModel>>(jsonString);
                }
                else
                {
                    //  _logger.LogError(jsonString);
                }

                return null;
            }
        }

        public async Task<IList<GenderModel>> GetAdmissionByGender(string gender)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7011/");
                var response = await client.GetAsync(String.Concat("Admission/gender?gender", gender.ToString()));
                string jsonString = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<List<GenderModel>>(jsonString);
                }
                else
                {
                    //  _logger.LogError(jsonString);
                }

                return null;
            }
        }
    }
}
