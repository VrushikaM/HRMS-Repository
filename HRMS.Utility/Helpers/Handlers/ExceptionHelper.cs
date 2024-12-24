namespace HRMS.Utility.Helpers.Handlers
{
    public class ExceptionHelper : Exception
    {
        public int StatusCode { get; set; }
        public string ExceptionMessage { get; set; }
        public string? ExceptionStackTrace { get; set; }
        public bool IsWarning { get; set; }

        public ExceptionHelper(string exceptionMessage)
        {
            ExceptionMessage = exceptionMessage;
        }

        public ExceptionHelper(Exception exception, bool isWarning, string exceptionMessage)
        {
            StatusCode = exception.HResult;
            ExceptionMessage = exceptionMessage + " | Original Message: " + exception.Message;
            ExceptionStackTrace = exception.StackTrace;
            IsWarning = isWarning;
        }
    }
}
