#region Using 
using Newtonsoft.Json;
using SdekService.Models;
#endregion

namespace SdekService.Services
{
    #region Class CityBuilder
    public static class CityBuilder
    {
        /// <summary>
        /// Вовращает город по ФИАС с помощью СДЭК API 
        /// </summary>
        /// <param name="fiasGuid"></param>
        /// <returns></returns>
        #region Public Methods
        public static async Task<City> CreateCityFromFiasGuid(Guid fiasGuid)
        {
            City city = new City();
            try
            {
                HttpClient client = new HttpClient();

                using HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, RequestURLs.CityUrl + fiasGuid);

                HttpResponseMessage data = client.SendAsync(requestMessage).Result;

                string jsonString = await data.Content.ReadAsStringAsync();

                List<City> cities = JsonConvert.DeserializeObject<List<City>>(jsonString);

                city = cities.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return city;
        }
        #endregion
    }
    #endregion
}
