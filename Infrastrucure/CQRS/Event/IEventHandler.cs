using MediatR;

namespace Infrastructure.CQRS.Event
{
    public interface IEventHandler<T> : INotificationHandler<T> where T : IEvent { }
}