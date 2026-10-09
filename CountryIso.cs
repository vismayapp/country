namespace country
{

    public class CountryIsoResponse
    {
        public bool Error { get; set; }
        public string Msg { get; set; }
        public List<CountryIso> Data { get; set; }
    }

    public class CountryIso
    {
        public string Name { get; set; }
        public string Iso2 { get; set; }
        public string Iso3 { get; set; }
    }
}