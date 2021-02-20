using ForestApp_CityApi_Entity;
using ForestAppBase.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForestApp_CityApi_DataAccess.Abstract
{
    public interface IDistrictRepository: IBaseRepository<CityApiDbContext, District>
    {
    }
}
