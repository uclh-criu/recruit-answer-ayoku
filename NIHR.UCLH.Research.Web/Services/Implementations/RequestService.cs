

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
        public async Task<int> GetAdmissionByAge(int age)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7011/");
                var response = await client.GetAsync(String.Concat("Admission/agecount?age=", age.ToString()));
                string jsonString = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<int>(jsonString);
                }
                else
                {
                    //  _logger.LogError(jsonString);
                }

                return 0;
            }

        }
        public async Task<int> GetAdmissionByEthinicity(string region)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7011/");
                var response = await client.GetAsync(String.Concat("Admission/ethincitycount?origin=", region.ToString()));
                string jsonString = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<int>(jsonString);
                }
                else
                {
                    //  _logger.LogError(jsonString);
                }

                return 0;
            }
        }

        public async Task<int> GetAdmissionByGender(string gender)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7011/");
                var response = await client.GetAsync(String.Concat("Admission/gendercount?gender", gender.ToString()));
                string jsonString = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                  //  return JsonConvert.DeserializeObject<List<GenderModel>>(jsonString);
                    return JsonConvert.DeserializeObject<int>(jsonString);
                }
                else
                {
                    //  _logger.LogError(jsonString);
                }

                return 0;
            }
        }
    }
}
