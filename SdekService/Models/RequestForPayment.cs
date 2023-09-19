
namespace SdekService.Models
{
    // класс для запроса об оплате
    public class RequestForPayment
    {
        public string version { get; set; } 
        public int senderCityId { get; set; }
        public int receiverCityId { get; set; } 

        public List<TariffId> tariffList { get; set; }
        public Goods goods { get; set; }
        public RequestForPayment() { }
    }
    
    // класс для тарифов доставки
    public class TariffId
    {
        public int id { get; set; }
        public TariffId() { }
    }
    
    // класс для характеристик посылки
    public class Goods
    {
        public float weight { get; set; }
        public int length { get; set; }
        public int width { get; set; }
        public int height {get;set;}
        public  Goods() { }
    }
}