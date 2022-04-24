using CryptSwitch.Models;

namespace CryptSwitch.Builders
{
    public interface ITradingModelBuilder
    {
        Task<ExchangeResults> LoadExchangeRates();
    }
}