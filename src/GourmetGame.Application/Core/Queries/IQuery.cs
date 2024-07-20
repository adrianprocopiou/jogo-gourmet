using MediatR;

namespace GourmetGame.Application.Core.Queries
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }
}
