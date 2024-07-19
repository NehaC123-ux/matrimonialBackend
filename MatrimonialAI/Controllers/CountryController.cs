using MatrimonialBusinessAccess_Layer.Interfaceservice;
using MatrimonialModel_Layer.DTO;
using Microsoft.AspNetCore.Mvc;

namespace MatrimonialAI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryRepoService _repoService;
        public CountryController(ICountryRepoService repoService)
        {
            this._repoService = repoService;
        }
        [HttpGet]
        [Route("GetCountryDetails")]
        public async Task<IActionResult> GetCountryDetails()
        {
            try
            {
                var result = await _repoService.GetAllCountryList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("PostNewDataCountry")]
        public async Task<IActionResult> PostNewDataCountry(CountryDto country)
        {
            try
            {
                await _repoService.NewCountryDetails(country);
                return Ok("Data Added Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("UpdateCountryData")]
        public async Task<IActionResult> UpdateCountryData(CountryDto country)
        {
            try
            {
                await _repoService.UpdateDataCountry(country);
                return Ok("update Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [HttpDelete]
        [Route("RemoveDetails")]
        public async Task<IActionResult> RemoveDetails(Guid Countryid)
        {
            try
            {
                await _repoService.DeleteCountryDetails(Countryid);
                return Ok("Delete Data Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("GetCountryById")]
        public async Task<IActionResult> GetCountryById(Guid Countryid)
        {
            try
            {
                var result = await _repoService.GetCountryDetailsById(Countryid);
                return Ok(result);  
            }
             catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
