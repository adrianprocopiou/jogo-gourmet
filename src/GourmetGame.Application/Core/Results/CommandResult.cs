using GourmetGame.Application.Core.Errors;

namespace GourmetGame.Application.Core.Results
{
    public class CommandResult<TResult>
    {
        private CommandResult() { }

        public List<BusinessError> Errors { get; private set; } = new List<BusinessError>();

        public bool HasSuccess => !Errors.Any();

        public TResult? Value { get; private set; }

        public static CommandResult<TResult> Fail(IEnumerable<BusinessError> errors)
        {
            var result = new CommandResult<TResult>();
            result.Errors.AddRange(errors);
            return result;
        }

        public static CommandResult<TResult> Fail(BusinessError error)
        {
            var result = new CommandResult<TResult>();
            result.Errors.Add(error);
            return result;
        }

        public static CommandResult<TResult> Fail(string message)
        {
            return Fail(new BusinessError(message));
        }

        public static CommandResult<TResult> Fail(string message, string property)
        {
            return Fail(new BusinessError(property, message));
        }

        public static CommandResult<TResult> Success(TResult result)
        {
            return new CommandResult<TResult> { Value = result };
        }
    }
}
