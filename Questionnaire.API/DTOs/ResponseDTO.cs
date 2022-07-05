namespace Questionnaire.API.DTOs
{
    public struct ResponseDTO
    {
        public bool IsSuccess { get; set; }
        public object Data { get; set; }
        public string Message { get; set; }

        public static ResponseDTO GenerateResponse(object _data, bool _isSuccess = true, string _message = "Transaction Successful!")
        {
            return new ResponseDTO() { IsSuccess = _isSuccess, Data = _data, Message = _message };
        }
    }
}
