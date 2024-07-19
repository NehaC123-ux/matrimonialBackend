using MatrimonialBusinessAccess_Layer.Interfaceservice;
using MatrimonialModel_Layer.DTO;
using Microsoft.AspNetCore.Mvc;

namespace MatrimonialAI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnquiryController : ControllerBase
    {
        private readonly IEnquiryRepoService _enquiryRepoService;
        public EnquiryController(IEnquiryRepoService RepoService)
        {
            this._enquiryRepoService = RepoService;
        }
        [HttpGet]
        [Route("GetEnquiryData")]
        public async Task<IActionResult> GetEnquiryData()
        {
            try
            {
                var result = await _enquiryRepoService.GetAllEnquiryList();
                return Ok(result);

            }
            catch
            (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost]
        [Route("PostEnquiryData")]
        public async Task<IActionResult> PostEnquiryData(EnquiryDto enquiry)
        {
            try
            {
                await _enquiryRepoService.AddDetailsEnquiry(enquiry);
                return Ok("Data Added successfully");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpDelete]
        [Route("DeleteEnquiry")]
        public async Task<IActionResult> PostEnquiryData(Guid enquiryId)
        {
            try
            {
                await _enquiryRepoService.DeleteDetailsEnquiry(enquiryId);
                return Ok("Deleted Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("GetEnquiryById")]
        public async Task<IActionResult> GetEnquiryById(Guid id)
        {
            try
            {
                var result = await _enquiryRepoService.GetDetailsEnquiryById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("EditeEnquiryData")]
        public async Task<IActionResult> EditeEnquiryData(EnquiryDto enquiry)
        {
            try
            {
                await _enquiryRepoService.UpdateDetailsEnquiry(enquiry);
                return Ok("updatd successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
