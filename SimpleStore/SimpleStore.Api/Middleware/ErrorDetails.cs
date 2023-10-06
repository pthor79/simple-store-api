namespace SimpleStore.Api.Middleware
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorType { get; set; }
    }
}
