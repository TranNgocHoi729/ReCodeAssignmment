
namespace Project.Application.Common.BaseDtos
{
    public class BaseResponseResult <T>
    {
        public T Result { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public static BaseResponseResult<T> Success(T result)
        {
            return new BaseResponseResult<T>
            {
                IsSuccess = true,
                Result = result
            };
        }

        public static BaseResponseResult<T> Faild (T result, string message)
        {
            return new BaseResponseResult<T>
            {
                IsSuccess = false,
                Result = result,
                Message = message
            };
        }
    }
}
