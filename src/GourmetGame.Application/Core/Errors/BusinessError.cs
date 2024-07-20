namespace GourmetGame.Application.Core.Errors
{
    public class BusinessError
    {
        public string? Property { get; set; }
        public string Message { get; }

        public BusinessError(string message)
        {
            Message = message;
        }

        public BusinessError(string message, string property)
        {
            Property = property;
            Message = message;
        }
    }
}
