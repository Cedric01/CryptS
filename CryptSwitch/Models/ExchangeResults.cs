namespace CryptSwitch.Models
{
    public class ExchangeResults
    {
        public ExchangeModel Status { get; set; }

        public List<CryptoListings> Data { get; set; }
    }
}
