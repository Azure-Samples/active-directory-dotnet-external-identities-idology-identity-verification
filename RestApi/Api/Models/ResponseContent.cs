namespace Api.Models
{
    using System.Net;
    using System.Reflection;

    public class ResponseContent
    {
        public ResponseContent(string code, string message, HttpStatusCode status, string action)
        {
            this.code = code;
            userMessage = message;
            this.status = (int) status;
            version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            this.action = action;
        }

        public string version { get; set; }

        public int status { get; set; }

        public string userMessage { get; set; }

        public string action { get; set; }

        public string code { get; set; }
    }
}