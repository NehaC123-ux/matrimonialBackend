using MatrimonialBusinessAccess_Layer.Interfaceservice;
using MatrimonialModel_Layer.DTO;
using Microsoft.AspNetCore.Mvc;

namespace MatrimonialAI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GotraController : ControllerBase
    {
        private readonly IGotraRepoService _gotraRepoService;
        public GotraController(IGotraRepoService RepoService)
        {
            this._gotraRepoService = RepoService;
        }
        [HttpGet]
        [Route("GetGotraList")]
        public async Task<IActionResult> GetGotraList()
        {
            try
            {
                var result = await _gotraRepoService.GetGotraList();
                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("PostDetailsGotra")]
        public async Task<IActionResult> PostDetailsGotra(GotraDto gotra)
        {
            try
            {
                await _gotraRepoService.AddGotraData(gotra);
                return Ok("Data not add Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("DeleteGotra")]
        public async Task<IActionResult> DeleteGotra(Guid gotraId)
        {
            try
            {
                await _gotraRepoService.DeleteDataGotra(gotraId);
                return Ok("Data Deleted Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("UpdateDatagotra")]
        public async Task<IActionResult> UpdateDatagotra(GotraDto gotra)
        {
            try
            {
                await _gotraRepoService.UpdateGotraDetails(gotra);
                return Ok("update data successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("GetGotraListById")]
        public async Task<IActionResult> GetGotraListById (Guid subcasteid)
        {
            try
            {
                var result = await _gotraRepoService.GetgotraById(subcasteid);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
