using MatrimonialModel_Layer.DTO;

namespace MatrimonialBusinessAccess_Layer.Interfaceservice
{
    public interface IEnquiryRepoService
    {
        Task<List<EnquiryDto>> GetAllEnquiryList();
        Task AddDetailsEnquiry(EnquiryDto enquiry);
        Task DeleteDetailsEnquiry(Guid enquiryId);
        Task<EnquiryDto> GetDetailsEnquiryById(Guid enquiryid);
        Task UpdateDetailsEnquiry(EnquiryDto enquiry);
    }
}
