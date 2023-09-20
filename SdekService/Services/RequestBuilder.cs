#region Using
using Newtonsoft.Json;
using SdekService.Models;
using SdekService.Models.Enums;
#endregion

namespace SdekService.Services
{
    #region Class RequestBuilder
    public static class RequestBuilder
    {
        #region Public Methods
        /// <summary>
        /// Возвращает результат запроса о стоимости доставки по заданными параметрам
        /// </summary>
        /// <param name="senderCity"></param>
        /// <param name="receiverCity"></param>
        /// <param name="weight_gr"></param>
        /// <param name="lenght_mm"></param>
        /// <param name="width_mm"></param>
        /// <param name="height_mm"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Возвращает сформированный запрос к СДЭК API по заданным параметрам
        /// </summary>
        /// <param name="senderCityId"></param>
        /// <param name="receiverCityId"></param>
        /// <param name="weight_gr"></param>
        /// <param name="lenght_mm"></param>
        /// <param name="width_mm"></param>
        /// <param name="height_mm"></param>
        /// <returns></returns>
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
        #endregion
    }
    #endregion
}
