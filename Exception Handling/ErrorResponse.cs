namespace PGManagement.Exception_Handling
{
    public class ErrorResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public string StackTrace { get; set; }

    }
}
