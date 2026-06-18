namespace RestApiDestinations
{
    public class CountryCodeService
    {
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
       

        public string GetCountryCode()
        {
            return CountryName = ("Österreich, Frankreich, Deutschland"); 
            return CountryCode = ("AT, FR, DE");
        }
    }
}
