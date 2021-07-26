using MediatR;
using System.Threading.Tasks;

namespace Infrastructure.CQRS.Event
{
    public class EventBus : IEventBus
    {
        private readonly IMediator _mediator;

        public EventBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task PublishAsync<T>(T @event) where T : IEvent
        {
            await _mediator.Publish(@event);
        }
    }
}