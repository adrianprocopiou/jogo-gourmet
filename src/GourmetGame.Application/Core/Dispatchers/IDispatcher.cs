using GourmetGame.Application.Core.Commands;
using GourmetGame.Application.Core.Queries;

namespace GourmetGame.Application.Core.Senders
{
    public interface IDispatcher
    {
        Task<TResponse> SendCommand<TResponse>(ICommand<TResponse> command, CancellationToken cancellationToken = default);
        Task<TResponse> SendQuery<TResponse>(IQuery<TResponse> query, CancellationToken cancellationToken = default);
    }
}
