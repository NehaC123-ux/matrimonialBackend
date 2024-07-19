using MatrimonialModel_Layer.DTO;

namespace MatrimonialBusinessAccess_Layer.Interfaceservice
{
    public interface IDistrictRepoService
    {
        Task<List<DistrictDto>> GetDistrictsList();
        Task AddNewDistrict(DistrictDto district);
        Task DeleteDistrict(Guid districtId);
        Task UpdateDataDistrict(DistrictDto district);
        Task<List<DistrictDto>> GetDistrictById(Guid stateid);
    }
}
