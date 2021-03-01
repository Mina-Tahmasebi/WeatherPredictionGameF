using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FunWeatherGame.ApiCaller
{
    public class ApiCaller
    {
        public static async Task<T> Call<T>(HttpMethod method, string url, object ContentList = null)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    StringContent content = null;
                    if (ContentList != null)
                        content = new StringContent(JsonConvert.SerializeObject(ContentList,
                    new JsonSerializerSettings()
                    {
                        ContractResolver = new CamelCasePropertyNamesContractResolver()
                    }), Encoding.UTF8, "application/json");

                    HttpResponseMessage response = new HttpResponseMessage();
                    response = method == HttpMethod.Get ? await httpClient.GetAsync(url) : await httpClient.PostAsync(url, content);
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    if (string.IsNullOrEmpty(apiResponse)) return default;
                    var res = JsonConvert.DeserializeObject<T>(apiResponse,
                    new JsonSerializerSettings()
                    {
                        ContractResolver = new CamelCasePropertyNamesContractResolver()
                    });
                    return res;
                }
            }
            catch (Exception ex)
            {
                return default;
            }
        }
    }
}
