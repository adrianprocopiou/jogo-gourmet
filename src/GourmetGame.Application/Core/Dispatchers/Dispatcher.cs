using GourmetGame.Application.Core.Commands;
using GourmetGame.Application.Core.Queries;
using GourmetGame.Application.Core.Senders;
using MediatR;

namespace GourmetGame.Application.Core.Dispatchers
{
    public class Dispatcher : IDispatcher
    {
        private readonly IMediator mediator;

        public Dispatcher(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public Task<TResponse> SendCommand<TResponse>(ICommand<TResponse> command, CancellationToken cancellationToken = default)
        {
            return mediator.Send(command, cancellationToken);
        }

        public Task<TResponse> SendQuery<TResponse>(IQuery<TResponse> query, CancellationToken cancellationToken = default)
        {
            return mediator.Send(query, cancellationToken);
        }
    }
}
