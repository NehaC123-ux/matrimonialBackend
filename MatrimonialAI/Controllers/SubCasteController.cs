using MatrimonialBusinessAccess_Layer.Interfaceservice;
using MatrimonialModel_Layer.DTO;
using Microsoft.AspNetCore.Mvc;

namespace MatrimonialAI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCasteController : ControllerBase
    {
        private readonly ISubCasteRepoService _subRepoService;
        public SubCasteController(ISubCasteRepoService subRepoService)
        {
            this._subRepoService = subRepoService;
        }
        [HttpGet]
        [Route("GetSubCasteDetails")]
        public async Task<IActionResult> GetSubCasteDetails()
        {
            try
            {
                var result = await _subRepoService.GetSubCasteList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("PostDetailsSubcaste")]
        public async Task<IActionResult> PostDetailsSubcaste(SubCasteDto subCaste)
        {
            try
            {
                await _subRepoService.AddDataSubCaste(subCaste);
                return Ok("Added Data Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("DeleteSubcaste")]
        public async Task<IActionResult> DeleteSubcaste(Guid subcasteId)
        {
            try
            {
                await _subRepoService.DeleteDataSubCaste(subcasteId);
                return Ok("Delete Data Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("UpdateDataSubCastes")]
        public async Task<IActionResult> UpdateDataSubCastes(SubCasteDto subCaste)
        {
            try
            {
                await _subRepoService.UpdateDataSubCaste(subCaste);
                return Ok("updated successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
