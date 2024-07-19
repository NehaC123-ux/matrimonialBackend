using MatrimonialModel_Layer.DTO;

namespace MatrimonialBusinessAccess_Layer.Interfaceservice
{
    public interface IStateRepoService
    {
        Task<List<StateDto>> GetAllStateList();
        Task AddNewState(StateDto state);
        Task<List<StateDto>> GetCountryById(Guid countryId);
        Task DeleteNewState(Guid StateId);
        Task UpdateNewState(StateDto state);
    }
}
