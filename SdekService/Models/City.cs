namespace SdekService.Models
{
    public class City
    {
        public string? cityName { get; set; }
        public int cityCode { get; set; }  
        public Guid cityUuid { get; set; }
        public string? country { get; set; }
        public string? countryCode { get; set; }
        public string? region { get; set; }
        public int regionCode { get; set; }
        public Guid regionFiasGuid { get; set; }
        public string? subRegion { get; set; }
        public float latitude { get; set; }
        public float longitude { get; set; }
        public string? kladr { get; set; }
        public Guid fiasGuid { get; set; }
        public float paymentLimit { get; set; }
        public string? timezone { get; set; }
        public City() { }

    }
}
