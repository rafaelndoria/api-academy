namespace Academy.Api.Helpers
{
    public class CustomExceptionMessageHelper
    {
        public static string ExceptionMessage(string message, Exception ex)
        {
            string innerExceptionMessage = ex.InnerException != null ? ex.InnerException.Message : "No inner exception message";

            string formattedMessage = string.Format(
                "{0}\nError message: {1}\nInner exception message: {2}",
                message,
                ex.Message,
                innerExceptionMessage);

            return formattedMessage;
        }
    }
}
