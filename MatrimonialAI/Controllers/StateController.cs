using MatrimonialBusinessAccess_Layer.Interfaceservice;
using MatrimonialModel_Layer.DTO;
using Microsoft.AspNetCore.Mvc;

namespace MatrimonialAI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IStateRepoService _stateRepoService;
        public StateController(IStateRepoService RepoService)
        {
            this._stateRepoService = RepoService;
        }
        [HttpGet]
        [Route("GetListOfState")]
        public async Task<IActionResult> GetListOfState()
        {
            try
            {
                var result = await _stateRepoService.GetAllStateList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("PostDetailsState")]
        public async Task<IActionResult> PostDetailsState(StateDto state)
        {
            try
            {
                await _stateRepoService.AddNewState(state);
                return Ok("Data Added Successfully");
            }
            catch
            (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("DeleteDataStates")]
        public async Task<IActionResult> DeleteDataStates(Guid StateId)
        {
            try
            {
                await _stateRepoService.DeleteNewState(StateId);
                return Ok("Delete Successfully");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("StateDataUpdated")]
        public async Task<IActionResult> StateDataUpdated(StateDto state)
        {
            try
            {
                await _stateRepoService.UpdateNewState(state);
                return Ok("Updated Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("GetStateById")]
        public async Task<IActionResult> GetStateById(Guid Id)
        {
            try
            {
                var res=await _stateRepoService.GetCountryById(Id);
                return Ok(res);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
    }
}
