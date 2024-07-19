using MatrimonialModel_Layer.DTO;

namespace MatrimonialBusinessAccess_Layer.Interfaceservice
{
    public interface IQualificationRepoService
    {
        Task<List<QualificationDto>> GetAllQualifications();
        Task NewQualificationData(QualificationDto Qualification);
        Task DeleteQualificationData(Guid QualificationId);
        Task UpdateDataQualification(QualificationDto Qualification);
    }
}
