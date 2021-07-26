using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.CQRS.Commands
{
    public class CommandBus : ICommandBus
    {
        #region [ Private Field(s) ]

        private readonly IMediator _mediator;

        #endregion

        #region [ Constructor(s) ]

        public CommandBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        #region [ Public Method(s) ]

        public virtual async Task<TResponse> Send<TResponse>(ICommand<TResponse> command, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);

            return result;
        }
        public virtual async Task Send(ICommand command, CancellationToken cancellationToken = default)
        {
            await _mediator.Send(command, cancellationToken);
        }

        #endregion
    }
}