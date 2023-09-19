namespace SdekService.Models
{
    // класс для результата запроса
    public class Result    
    {
        public List<DeliveryDetails> result { get; set; }
    }
    
    // класс для деталей доставки, полученных в Result
    public class DeliveryDetails
    {
        public int tariffId { get; set; }
        public string status { get; set; }
        public ResultForOne result { get; set; }     
    }

    // класс для результатов запроса о стоимости доставки, если доставка возможна
    public class ResultForOne
    {
        public double price { get; set; }
        public int deliveryPeriodMin { get; set; }
        public int deliveryPeriodMax { get; set; }
        public float priceByCurrency { get; set; }
        public string currency { get; set; }        
        public Error errors { get; set; }
    }

    // класс для ошибки, если доставка не возможно
    public class Error
    {
        public int code { get; set; }
        public string text { get; set; }
    }
}
