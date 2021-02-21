using ForestApp_IdentifiyApi_Entity.ParameterModels;
using ForestApp_IdentifyApi_Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ForestApp_IdentifiyApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]


    public class AuthController : AuthApiBaseController
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost("Register")]
        public async Task<IActionResult> register([FromBody] UserRegisterModel userRegisterModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   // InfoLog(ControllerContext.ActionDescriptor.DisplayName);
                    var result = await _userService.Register(userRegisterModel);
                    if (result.isSuccess != null && result.isSuccess == true)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return Ok(result);
                        //login error
                    }
                }
                return BadRequest();


            }
            catch (Exception exception)
            {
                return ErrorInternal(exception, $"{ControllerContext.ActionDescriptor.DisplayName} Exception Message : {exception.Message} - {exception.InnerException}");

            }
        }
    }
}
