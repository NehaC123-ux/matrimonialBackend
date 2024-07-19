using MatrimonialBusinessAccess_Layer.Interfaceservice;
using MatrimonialModel_Layer.DTO;
using Microsoft.AspNetCore.Mvc;

namespace MatrimonialAI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController : ControllerBase
    {
        private readonly IDistrictRepoService _districtRepoService;
        public DistrictController(IDistrictRepoService RepoService)
        {
            this._districtRepoService = RepoService;
        }
        [HttpGet]
        [Route("GetDistrictDetails")]
        public async Task<IActionResult> GetDistrictDetails()
        {
            try
            {
                var result = await _districtRepoService.GetDistrictsList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("PostDataDistrict")]
        public async Task<IActionResult> PostDataDistrict(DistrictDto district)
        {
            try
            {
                await _districtRepoService.AddNewDistrict(district);
                return Ok("Data Added Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("DistrictDataDelete")]
        public async Task<IActionResult> DistrictDataDelete(Guid districtId)
        {
            try
            {
                await _districtRepoService.DeleteDistrict(districtId);
                return Ok("Delete Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("updateDataDistrict")]
        public async Task<IActionResult> updateDataDistrict(DistrictDto district)
        {
            try
            {
                await _districtRepoService.UpdateDataDistrict(district);
                return Ok("Updated Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("GetDistrictById")]
        public async Task<IActionResult> GetDistrictById(Guid id)
        {
            try
            {
                var result= await _districtRepoService.GetDistrictById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }


}
