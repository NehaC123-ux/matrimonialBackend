using MatrimonialBusinessAccess_Layer.Interfaceservice;
using MatrimonialModel_Layer.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MatrimonialAI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewRegistrationController : ControllerBase
    {
        private readonly INewRegistrationService _service;
        public NewRegistrationController(INewRegistrationService newRegistration)
        {
            this._service = newRegistration;        
        }
        [HttpGet]
        [Route("GetNewregistration")]
        public async Task<IActionResult> GetNewregistration()
        {
            try
            {
                var res=await _service.GetNewRegistrationList();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("PostNewRegistration")]
        public async Task<IActionResult> PostNewRegistration(NewRegistrationDtoModel newRegistrationDto)
        {
            try
            {
               var id=  await _service.AddNewRagistrationData(newRegistrationDto);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("DeleteNewRegistration")]
        public async Task<IActionResult> DeleteNewRegistration(Guid profileId)
        {
            try
            {
                await _service.DeleteNewRegistration(profileId);
                return Ok("deleted SuccessFully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("GetNewResById")]
        public async Task<IActionResult> GetNewResById(Guid id)
        {
            try
            {
                var result = await _service.GetNewRegistrationRecordById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("UpdateNewRegistration")]
        public async Task <IActionResult> UpdateNewRegistration(NewRegistrationDtoModel newRegistrationDto)
        {
            try
            {
                await _service.UpdateNewRegistrationRecord(newRegistrationDto);
                return Ok("Updated successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("GetAllDetailsWithName")]
        public async Task<object> GetAllDetailsWithName()
        {
            try
            {
                var res =await _service.getRegistrationAllDropdown();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
