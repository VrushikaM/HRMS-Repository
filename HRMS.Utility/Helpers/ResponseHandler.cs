using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HRMS.Utility.Helper
{
    public class ResponseHandler
    {
        public string? status { get; set; }
        public string? message { get; set; }
        public object? data { get; set; }

        public ResponseHandler(string status, string message, object? data = null)
        {
            this.status = status;
            this.message = message;
            this.data = data;
        }

        public ResponseHandler(string status, string message)
        {
            this.status = status;
            this.message = message;
            data = null;
        }

        public static ResponseHandler Success(string message, object? data = null)
        {
            return new ResponseHandler("Success", message, data);
        }

        public static ResponseHandler Success(string message)
        {
            return new ResponseHandler("Success", message);
        }

        public static ResponseHandler Error(string message)
        {
            return new ResponseHandler("Error", message);
        }
        public Dictionary<string, object?> ToDictionary()
        {
            var responseDict = new Dictionary<string, object?>
            {
                { "status", status },
                { "message", message }
            };

            if (data != null)
            {
                responseDict.Add("data", data);
            }

            return responseDict;
        }
    }
}
