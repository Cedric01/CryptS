namespace CryptSwitch.DTO
{
    public class ExchangeResultsDTO
    {
        public ExchangeModelDTO Status { get; set; }

        public List<CryptoListingDTO> Data { get; set; }
    }
}
