using Newtonsoft.Json;
using SdekService.Models;
using SdekService.Models.Enums;

namespace SdekService.Services
{
    public class RequestBuilder
    {
        // Метод запроса расчета стоимости доставки к Сдэк Api
        public static async Task<Result> GetRequestForPayment(City senderCity, City receiverCity, int weight_gr, int lenght_mm, int width_mm, int height_mm)
        {
            Result? result = null;

            try
            {
                HttpClient client = new HttpClient();

                RequestForPayment requestForPayment = CreateRequestForPayment(senderCity.cityCode, receiverCity.cityCode, weight_gr, lenght_mm, width_mm, height_mm);

                JsonContent content = JsonContent.Create(requestForPayment);

                using HttpResponseMessage response = await client.PostAsync(RequestURLs.PayUrl,content);

                string? data = response.Content.ReadAsStringAsync().Result;

                result = JsonConvert.DeserializeObject<Result>(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result == null ? new Result() : result;            
        }

        // Метод сборки json файла для запроса
        private static RequestForPayment CreateRequestForPayment(int senderCityId, int receiverCityId, int weight_gr, int lenght_mm, int width_mm, int height_mm)
        {
            return new RequestForPayment()
            {
                version = "1.0",
                senderCityId = senderCityId,
                receiverCityId = receiverCityId,
                tariffList = new List<TariffId>()
                {
                    new TariffId {id=(int)TarrifType.ExpressStockDoor},
                    new TariffId{id =(int)TarrifType.ExpressStockStock}
                },
                goods = new Goods()
                {
                    weight = Utils.MakeWeightFromGrammToKG(weight_gr),
                    length = Utils.MakeParamFromMmToCm(lenght_mm),
                    width = Utils.MakeParamFromMmToCm(width_mm),
                    height = Utils.MakeParamFromMmToCm(height_mm)
                }
            };
        }
    }
}
