using System.Threading.Tasks;

namespace Infrastructure.CQRS.Event
{
    public interface IEventBus
    {
        Task PublishAsync<T>(T @event) where T : IEvent;
    }
}