using MatrimonialModel_Layer.DTO;

namespace MatrimonialBusinessAccess_Layer.Interfaceservice
{
    public interface IGotraRepoService
    {
        Task<List<GotraDto>> GetGotraList();
        Task AddGotraData(GotraDto gotra);
        Task DeleteDataGotra(Guid gotraId);
        Task<List<GotraDto>> GetgotraById(Guid subcasteId);
        Task UpdateGotraDetails(GotraDto gotra);
    }
}
