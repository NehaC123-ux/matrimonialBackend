using MatrimonialModel_Layer.DTO;

namespace MatrimonialBusinessAccess_Layer.Interfaceservice
{
    public interface ICountryRepoService
    {
        Task<List<CountryDto>> GetAllCountryList();
        Task NewCountryDetails(CountryDto country);
        Task DeleteCountryDetails(Guid CountryId);
        Task UpdateDataCountry(CountryDto country);
        Task<CountryDto> GetCountryDetailsById(Guid CountryId);
    }
}
