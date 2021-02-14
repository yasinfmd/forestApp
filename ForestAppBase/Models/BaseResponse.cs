using System;
namespace ForestAppBase.Models
{
    public class BaseResponse<T> where T : class
    {
        public T Result { get; set; }
        public bool IsSuccess { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
