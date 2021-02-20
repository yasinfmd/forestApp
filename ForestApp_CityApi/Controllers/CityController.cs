using ForestApp_CityApi_Business.Abstract;
using ForestApp_CityApi_Dto;
using ForestAppBase.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ForestApp_CityApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CityController : CityApiBaseController
    {
        private readonly ICityService _cityService;
        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }
        // GET: api/<CityController>
        [HttpGet("All")]
        [ProducesResponseType(typeof(BaseResponse<IEnumerable<CityDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(IEnumerable<ErrorModel>), StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<IActionResult> Index()
        {
            try
            {
                var response =await _cityService.GetAll();
                return Ok(response);
            }
            catch (Exception exception)
            {
                return ErrorInternal(exception, $"{ControllerContext.ActionDescriptor.DisplayName} Exception Message : {exception.Message} - {exception.InnerException}");
            }
           // return new string[] { "value1", "value2" };
        }

        // GET api/<CityController>/5
        [HttpGet("Show/{id}")]
        public async Task<IActionResult> Show(Guid id)
        {
            try
            {
                var response = await _cityService.GetCity(id);
                return Ok();
            }
            catch (Exception exception)
            {
                return ErrorInternal(exception, $"{ControllerContext.ActionDescriptor.DisplayName} Exception Message : {exception.Message} - {exception.InnerException}");
            }
        }
    }
}
