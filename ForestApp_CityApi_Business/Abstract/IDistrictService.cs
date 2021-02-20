using ForestApp_CityApi_Dto;
using ForestAppBase.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ForestApp_CityApi_Business.Abstract
{
    public interface IDistrictService
    {
        Task<BaseResponse<IEnumerable<DistrictDto>>> GetAll();
    }
}
