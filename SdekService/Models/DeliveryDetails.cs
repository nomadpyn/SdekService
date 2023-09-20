namespace SdekService.Models
{
    #region Class Result
    /// <summary>
    /// Класс для результата запроса по стоимости доставки 
    /// </summary>
    public class Result    
    {
        public List<DeliveryDetails> result { get; set; }
    }
    #endregion

    #region Class DeliveryDetails
    /// <summary>
    /// Класс для деталей доставки, полученных в класс Result
    /// </summary>
    public class DeliveryDetails
    {
        public int tariffId { get; set; }
        public string status { get; set; }
        public ResultForOne result { get; set; }     
    }
    #endregion

    #region Class ResultForOne
    /// <summary>
    /// Класс для результатов запроса о стоимости доставки, когда доставка возможна
    /// </summary>
    public class ResultForOne
    {
        public double price { get; set; }
        public int deliveryPeriodMin { get; set; }
        public int deliveryPeriodMax { get; set; }
        public float priceByCurrency { get; set; }
        public string currency { get; set; }        
        public Error errors { get; set; }
    }
    #endregion

    #region Class Error
    /// <summary>
    /// Класс для ошибки, когда доставка не возможна
    /// </summary>
    public class Error
    {
        public int code { get; set; }
        public string text { get; set; }
    }
    #endregion
}
