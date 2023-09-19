using Microsoft.AspNetCore.Mvc;
using SdekService.Models;
using SdekService.Services;

namespace SdekService.Controllers
{
    [ApiController]
    [Route ("Home")]
    public class SdekControllers : Controller
    {        
        // метод получения стоимости доставки по заданным параметрам (фиас города отправителя, фиас города получателя, вес, длина, ширина и высота)
        [HttpGet]
        [Route("costOfDelivery")]
        public async Task<IActionResult> costOfDelivery(Guid senderCityGuid, Guid receiverCityGuid, int weight_gr, int lenght_mm, int width_mm, int height_mm)
        {
            City senderCity = await CityBuilder.CreateCityFromFiasGuid(senderCityGuid);

            City receiverCity = await CityBuilder.CreateCityFromFiasGuid(receiverCityGuid);

            if (senderCity == null || receiverCity == null)
                return BadRequest("Не верно заданы ФИАС городов");

            if(Utils.CheckAllParameters(weight_gr, lenght_mm, width_mm, height_mm))
                return BadRequest("Не верно заданы параметры посылки");

            Result result = await RequestBuilder.GetRequestForPayment(senderCity, receiverCity, weight_gr, lenght_mm, width_mm, height_mm);

            if (result.result is null)
                return BadRequest("Ваш запрос вернул ошибку, проверьте введенные данные");

            return Ok(result);
        }
    }
}
