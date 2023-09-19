namespace SdekService.Services
{
    // статический класс для хранения запросов к сдэк api 1.5
    public static class RequestURLs
    {
        // строка запроса по поиску города по ФИАС
        public static string CityUrl { get; } = "https://integration.cdek.ru/v1/location/cities/json?fiasGuid=";
        
        // строка запроса по расчету стоимости доставки
        public static string PayUrl { get; } = "http://api.cdek.ru/calculator/calculate_tarifflist.php";
    }
}
