namespace SdekService.Services
{
    #region Class RequestURLs
    /// <summary>
    /// Класс для хранения URL для запросов в СДЭК Api
    /// </summary>
    public static class RequestURLs
    {
        #region Public Fields
        public static string CityUrl { get; } = "https://integration.cdek.ru/v1/location/cities/json?fiasGuid=";                
        public static string PayUrl { get; } = "http://api.cdek.ru/calculator/calculate_tarifflist.php";
        #endregion
    }
    #endregion
}
