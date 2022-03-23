namespace CryptSwitch.DTO
{
    public class ExchangeModelDTO
    {
        public DateTime TimeStamp { get; set; }
        public int Error_Code { get; set; }
        public string Error_Message { get; set; }
        public int Elapsed { get; set; }

        public int credit_count { get; set; }

        public string Notice { get; set; }

        public int Total_Count { get; set; }
    }
}
