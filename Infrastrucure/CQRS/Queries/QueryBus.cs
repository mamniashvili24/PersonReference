using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.CQRS.Queries
{
    public class QueryBus : IQueryBus
    {
        #region [ Private Field(s) ]

        private readonly IMediator _mediator;

        #endregion

        #region [ Constructor(s) ]

        public QueryBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        #region [ Public Method(s) ]

        public virtual async Task<TResponse> Send<TResponse>(IQuery<TResponse> query, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(query, cancellationToken);

            return result;
        }

        #endregion
    }
}