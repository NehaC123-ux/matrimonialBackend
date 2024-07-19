using MatrimonialBusinessAccess_Layer.Interfaceservice;
using MatrimonialModel_Layer.DTO;
using Microsoft.AspNetCore.Mvc;

namespace MatrimonialAI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QualificationController : ControllerBase
    {
        private readonly IQualificationRepoService _repoService;
        public QualificationController(IQualificationRepoService repoService)
        {
            this._repoService = repoService;
        }
        [HttpGet]
        [Route("GetQualification")]
        public async Task<IActionResult> GetQualification()
        {
            try
            {
                var result = await _repoService.GetAllQualifications();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("PostDetaQualification")]
        public async Task<IActionResult> GetQualification(QualificationDto qualification)
        {
            try
            {
                await _repoService.NewQualificationData(qualification);
                return Ok("Added Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("RemoveQualification")]
        public async Task<IActionResult> RemoveQualification(Guid id)
        {
            try
            {
                await _repoService.DeleteQualificationData(id);
                return Ok("Deleted Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("UpdateQualification")]
        public async Task<IActionResult> UpdateQualification(QualificationDto qualification)
        {
            try
            {
                await _repoService.UpdateDataQualification(qualification);
                return Ok("updated Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
