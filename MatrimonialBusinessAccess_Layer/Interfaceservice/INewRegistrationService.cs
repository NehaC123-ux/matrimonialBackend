using MatrimonialModel_Layer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrimonialBusinessAccess_Layer.Interfaceservice
{
    public interface INewRegistrationService
    {
        Task<List<NewRegistrationDtoModel>> GetNewRegistrationList();
        Task<Guid> AddNewRagistrationData(NewRegistrationDtoModel model);
        Task DeleteNewRegistration(Guid profileId);
        Task UpdateNewRegistrationRecord(NewRegistrationDtoModel newRegistration);
        Task<NewRegistrationDtoModel> GetNewRegistrationRecordById(Guid profileId); 
       Task<object> getRegistrationAllDropdown();
        
    }
}
