using ForestApp_CityApi_Dto;
using ForestApp_CityApi_Entity;
using ForestAppBase.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ForestApp_CityApi_Business.Abstract
{
    public interface ICityService
    {
       Task<BaseResponse<IEnumerable<CityDto>>> GetAll();

        Task<BaseResponse<CityDto>> GetCity(Guid id);


    }
}
