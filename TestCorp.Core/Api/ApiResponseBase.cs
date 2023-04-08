namespace TestCorp.Core.Api
{
    public class ApiResponseBase
    {
        public int Status { get; set; }
        public string ErrorMessage { get; set; } = String.Empty;
        public object? Data { get; set; }
    }
}
