namespace Excqape
{
    public struct Response
    {
        public string ErrorMessage { get; }
        public ErrorCode? ErrorCode { get; }

        public bool IsSuccess => !ErrorCode.HasValue;

        public Response(ErrorCode errorCode, string errorMessage)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
        }
    }

    public struct Response<T>
    {
        public T Data { get; }
        public string ErrorMessage { get; }
        public ErrorCode? ErrorCode { get; }

        public bool IsSuccess => !ErrorCode.HasValue;

        public Response(T data)
        {
            Data = data;
            ErrorCode = null;
            ErrorMessage = null;
        }

        public Response(ErrorCode errorCode, string errorMessage)
        {
            Data = default(T);
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
        }
    }

    public enum ErrorCode
    {
        NotFound,
        GeneralError
    }
}
