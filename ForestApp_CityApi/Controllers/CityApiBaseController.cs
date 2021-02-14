using ForestAppBase.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForestApp_CityApi.Controllers
{
    public class CityApiBaseController: ControllerBase
    {
        public CityApiBaseController()
        {

        }

        protected ObjectResult ErrorInternal(Exception exception, string message)
        {
            //_logger.LogError(exception, message);

            return StatusCode(500, new ErrorModel(exception.GetHashCode().ToString(), exception.Message));
        }
    }
}
