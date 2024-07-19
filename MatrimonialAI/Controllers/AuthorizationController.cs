using MatrimonialBusinessAccess_Layer.Interfaceservice;
using MatrimonialModel_Layer.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MatrimonialAI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly IUserService _userService;
        public AuthorizationController(IUserService userService)
        {
            this._userService = userService;   
        }
        [HttpPost]
        [Route("AddUser")]
        public async Task<IActionResult> AddUser(RegisterModelDto registerModel)
        {
            try
            {
                await _userService.AddRegistration(registerModel);
                return Ok("User Add SuccessFully");
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
              
            
           
        }
        [HttpPost]
        [Route("UserList")]
        public async Task<IActionResult> UserList(LoginDtoModel dtoModel)
        {
            if(ModelState.IsValid)
            {
                var token=await _userService.LoginUser(dtoModel);
                return Ok(token);
            }
            return BadRequest();
        }
        [HttpGet]
        [Route("GetUserList")]
        public async Task<IActionResult> GetUserList()
        {
            var res = await _userService.getUserName();
            return Ok(res);
        }
    }
}
