using MatrimonialModel_Layer.DTO;

namespace MatrimonialBusinessAccess_Layer.Interfaceservice
{
    public interface IProfessionRepoService
    {
        Task<List<ProfessionDto>> getProfessionList();
        Task addProfessionDetails(ProfessionDto profession);
        Task updateProfessionDetails(ProfessionDto profession);
        Task deleteProfessionDetails(Guid professionId);
    }
}
