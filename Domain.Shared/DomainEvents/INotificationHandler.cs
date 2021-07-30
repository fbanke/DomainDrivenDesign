using System.Threading.Tasks;

namespace Domain.Shared.DomainEvents
{
    public interface INotificationHandler<in TNotification>
        where TNotification : INotification
    {
        void Handle(TNotification notification);
    }
}