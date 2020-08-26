using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Passwords.Server.Models;
using Passwords.Server.Services;

namespace Passwords.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class PasswordInfoController : ControllerBase
    {
        private IPasswordInfoService passwordInfoService;

        public PasswordInfoController(IPasswordInfoService passwordInfoService)
        {
            this.passwordInfoService = passwordInfoService;
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] PasswordInfoRequest model)
        {
            passwordInfoService.Add(model);
            return Ok();
        }

        [HttpGet("getall/{id}")]
        public IActionResult GetAll(int id)
        {
            /*var result = new List<PasswordInfo>();
            result.Add(new PasswordInfo
            {
                Id = 1,
                Login = "asdasd",
                Name = "asdasd",
                OldPassword = "asdsa",
                Password = "sadsad"
            });
            return Ok(result);*/
            
            return Ok(passwordInfoService.GetAll(id));
        }
    }
}
