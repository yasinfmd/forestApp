using AutoMapper;
using ForestApp_CityApi_Business.Abstract;
using ForestApp_CityApi_DataAccess.Abstract;
using ForestApp_CityApi_Dto;
using ForestApp_CityApi_Entity;
using ForestAppBase.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ForestApp_CityApi_Business.Concrate
{
    public class CityManager : ICityService
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;
        private readonly IRedisCacheService _redisCacheService;

        //private readonly IFilesService _filesService;
        //private readonly IConfiguration _configuration;
        //private readonly IHelper _helper;

        public CityManager(ICityRepository cityRepository,IMapper mapper,IRedisCacheService redisCacheService)
        {
            _redisCacheService = redisCacheService;
            _mapper = mapper;
            _cityRepository = cityRepository;
        }
        public async Task<BaseResponse<IEnumerable<CityDto>>> GetAll()
        {
            BaseResponse<IEnumerable<CityDto>> baseResponse = new BaseResponse<IEnumerable<CityDto>>();
            string key = "District_" + DateTime.Now.ToString("yyyyMMdd_hh");
            var keyExists = await _redisCacheService.Contains(key);
            if (keyExists)
            {
                var recordsInCache = _redisCacheService.Get<IEnumerable<CityDto>>(key);
                baseResponse.IsSuccess = true;
                baseResponse.TimeStamp = DateTime.Now;
                baseResponse.Result = recordsInCache;
            }
            else
            {
                var result = await _cityRepository.GetAll();
                var mappedResult = _mapper.Map<IEnumerable<CityDto>>(result);
                baseResponse.IsSuccess = true;
                baseResponse.TimeStamp = DateTime.Now;
                baseResponse.Result = mappedResult;
                _redisCacheService.SetAsync<IEnumerable<CityDto>>(key, mappedResult);
            }
            return baseResponse;
        }

        public  async Task<BaseResponse<CityDto>> GetCity(Guid id)
        {
            BaseResponse<CityDto> baseResponse = new BaseResponse<CityDto>();
          

            var result = await _cityRepository.GetByGuidId(id);
            var mappedResult = _mapper.Map<CityDto>(result);
            baseResponse.IsSuccess = true;
            baseResponse.TimeStamp = DateTime.Now;
            baseResponse.Result = mappedResult;
           
            return baseResponse;
        }
    }
}
