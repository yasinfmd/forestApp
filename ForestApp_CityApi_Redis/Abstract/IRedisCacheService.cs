using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ForestApp_CityApi_Redis.Abstract
{

        public interface IRedisCacheService
        {
            //<T> where T:class
            void SetAsync<T>(string recordId, T data);
            T Get<T>(string recordId);

            Task<bool> Contains(string recordId);

            Task Remove(string recordId);

            Task<bool> Clear();
    }
}
