using AutoMapper;
using ForestApp_CityApi_Business.Abstract;
using ForestApp_CityApi_Business.Consts;
using ForestApp_CityApi_DataAccess.Abstract;
using ForestApp_CityApi_Dto;
using ForestAppBase.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ForestApp_CityApi_Business.Concrate
{
    public class DistrictManager : IDistrictService
    {
        private readonly IDistrictRepository _districtRepository;
        private readonly IMapper _mapper;
        private readonly IRedisCacheService _redisCacheService;
        public DistrictManager(IDistrictRepository districtRepository, IMapper mapper,IRedisCacheService redisCacheService)
        {
            _redisCacheService = redisCacheService;
            _districtRepository = districtRepository;
            _mapper = mapper;
        }
        public async Task<BaseResponse<IEnumerable<DistrictDto>>> GetAll()
        {
            BaseResponse<IEnumerable<DistrictDto>> baseResponse = new BaseResponse<IEnumerable<DistrictDto>>();
            string key = RedisConsts.District + DateTime.Now.ToString("yyyyMMdd_hh");
            var keyExists = await _redisCacheService.Contains(key);
            if (keyExists)
            {
                var recordsInCache = _redisCacheService.Get<IEnumerable<DistrictDto>>(key);
                baseResponse.IsSuccess = true;
                baseResponse.TimeStamp = DateTime.Now;
                baseResponse.Result = recordsInCache;
            }
            else
            {
                var result = await _districtRepository.GetAll();
                var mappedResult = _mapper.Map<IEnumerable<DistrictDto>>(result);
                baseResponse.Result = mappedResult;
                _redisCacheService.SetAsync<IEnumerable<DistrictDto>>(key, mappedResult);
            }
            //await _redisCacheService.Clear();
            return baseResponse;
        }
    }
}
