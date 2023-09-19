using Newtonsoft.Json;
using SdekService.Models;

namespace SdekService.Services
{
    public static class CityBuilder
    {
        // метод для получения информации о городе от Сдэк Api по ФИАС города, который приходит из запроса
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
    }
}
