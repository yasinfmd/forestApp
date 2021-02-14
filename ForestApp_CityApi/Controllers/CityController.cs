using ForestApp_CityApi_Business.Abstract;
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
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CityController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CityController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CityController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
