using MatrimonialModel_Layer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrimonialBusinessAccess_Layer.Interfaceservice
{
    public interface IUserService
    {
        Task<List<RegisterModelDto>> getUserName();
        Task AddRegistration(RegisterModelDto registerModelDto);
        Task<string> LoginUser(LoginDtoModel dtoModel);

    }
}
