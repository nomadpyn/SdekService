
namespace SdekService.Models
{
    #region Class RequestForPayment
    /// <summary>
    /// Класс для хранения запроса стоимости доставки
    /// </summary>
    public class RequestForPayment
    {
        public string version { get; set; } 
        public int senderCityId { get; set; }
        public int receiverCityId { get; set; } 

        public List<TariffId> tariffList { get; set; }
        public Goods goods { get; set; }
        public RequestForPayment() { }
    }
    #endregion

    #region Class TariffId
    /// <summary>
    /// Класс для тарифов доставки
    /// </summary>
    public class TariffId
    {
        public int id { get; set; }
        public TariffId() { }
    }
    #endregion

    #region Class Goods
    /// <summary>
    /// Класс для характеристик посылки
    /// </summary>
    public class Goods
    {
        public float weight { get; set; }
        public int length { get; set; }
        public int width { get; set; }
        public int height {get;set;}
        public  Goods() { }
    }
    #endregion
}