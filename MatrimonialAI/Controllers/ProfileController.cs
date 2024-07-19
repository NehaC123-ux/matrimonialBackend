using MatrimonialBusinessAccess_Layer.Interfaceservice;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MatrimonialAI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {

        private readonly IProfileService _profileService;
        public ProfileController(IProfileService profile)
        { 
            this._profileService = profile;
        }

       [HttpPost("MultipleUploadImage")]
      public async Task<IActionResult> MultipleUploadImage([FromForm]IFormFile[] file,[FromForm]Guid userId)
        {
            await _profileService.uploadImage(file,userId);
            return Ok("Image uploaded successfully");
        }

        [HttpPost, DisableRequestSizeLimit]
        [Route("upload-profile-image")]
        public async Task<IActionResult> UploadImage()
        {
           // await _profileService.uploadImage(file, userId);
            return Ok("Image uploaded successfully");
        }



    }
}
