using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.CQRS.Commands
{
    public interface ICommandBus
    {
        Task Send(ICommand command, CancellationToken cancellationToken = default(CancellationToken));
        Task<TResponse> Send<TResponse>(ICommand<TResponse> command, CancellationToken cancellationToken = default(CancellationToken));
    }
}