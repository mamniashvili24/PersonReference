using Infrastructure.CommonTypes.Abstractions;

namespace Infrastructure.CommonTypes.Implementations
{
    public class DataResponse<T> : IDataResponse<T>
    {
        public T Data { get; set; }
        public bool IsError { get; set; }
        public string Message { get; set; }
    }

    public class DataResponse : IDataResponse
    {
        public bool IsError { get; set; }
        public string Message { get; set; }
    }
}