using MediatR;

namespace GourmetGame.Application.Core.Commands
{
    public interface ICommand<out TResponse> : IRequest<TResponse>
    {
    }
}
