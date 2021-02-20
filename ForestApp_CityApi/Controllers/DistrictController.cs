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
    public class DistrictController : CityApiBaseController


    {
        private readonly IDistrictService _districtService;
        public DistrictController(IDistrictService districtService )
        {
            _districtService = districtService;
        }

        // GET: api/<DistrictController>
        [ProducesResponseType(typeof(BaseResponse<IEnumerable<DistrictDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(IEnumerable<ErrorModel>), StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [HttpGet("All")]
        public async Task<IActionResult> Index()
        {
            try
            {
                var result = await _districtService.GetAll();
                return Ok(result);
            }
            catch (Exception exception)
            {
                return ErrorInternal(exception, $"{ControllerContext.ActionDescriptor.DisplayName} Exception Message : {exception.Message} - {exception.InnerException}");
            }

        }
    }
}
