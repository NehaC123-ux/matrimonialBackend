using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MatrimonialBusinessAccess_Layer.Interfaceservice
{
    public interface IProfileService
    {
        Task uploadImage([FromForm]IFormFile[] file,[FromForm] Guid ProfileId);
     
    }

   
}
