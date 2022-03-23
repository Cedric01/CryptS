using AutoMapper;
using CryptSwitch.DTO;
using CryptSwitch.Models;

namespace CryptSwitch.Profiles
{
    public class CrypoListingProfile : Profile
    {
        public CrypoListingProfile()
        {
            //Source - > Target
            CreateMap<ExchangeResults, ExchangeResultsDTO>();
            CreateMap<CryptoListings, CryptoListingDTO>();
            CreateMap<ExchangeModel, ExchangeModelDTO>();
        }
    }
}
