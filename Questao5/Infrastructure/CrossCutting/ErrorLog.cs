namespace Questao5.Infrastructure.CrossCutting
{
    public class ErrorLog
    {

        public string Message { get; set; }

        public string InnerException { get; set; }

        public string StackTrace { get; set; }
    }
}
