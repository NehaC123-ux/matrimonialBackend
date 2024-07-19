using MatrimonialModel_Layer.DTO;

namespace MatrimonialBusinessAccess_Layer.Interfaceservice
{
    public interface ISubCasteRepoService
    {
        Task<List<SubCasteDto>> GetSubCasteList();
        Task AddDataSubCaste(SubCasteDto subCaste);
        Task DeleteDataSubCaste(Guid subCasteId);
        Task UpdateDataSubCaste(SubCasteDto dataSubCaste);
    }
}
