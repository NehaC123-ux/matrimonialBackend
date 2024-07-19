using MatrimonialBusinessAccess_Layer.Interfaceservice;
using MatrimonialModel_Layer.DTO;
using Microsoft.AspNetCore.Mvc;

namespace MatrimonialAI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessionController : ControllerBase
    {
        private readonly IProfessionRepoService _professionRepoService;
        public ProfessionController(IProfessionRepoService professionRepo)
        {
            this._professionRepoService = professionRepo;
        }
        [HttpGet]
        [Route("GetProfessionData")]
        public async Task<IActionResult> GetProfessionData()
        {
            try
            {
                var result = await _professionRepoService.getProfessionList();
                return Ok(result);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("AddPostProfession")]
        public async Task<IActionResult> AddPostProfession(ProfessionDto profession)
        {
            try
            {
                await _professionRepoService.addProfessionDetails(profession);
                return Ok("Add Profession Data Successfully");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpDelete]
        [Route("DeleteDataProfession")]
        public async Task<IActionResult> DeleteDataProfession(Guid professionId)
        {
            try
            {
                await _professionRepoService.deleteProfessionDetails(professionId);
                return Ok("Data of profession Deleted Successfully");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPut]
        [Route("EditDataProfession")]
        public async Task<IActionResult> EditDataProfession(ProfessionDto profile)
        {
            try
            {
                await _professionRepoService.updateProfessionDetails(profile);
                return Ok("Updated Successfully");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
