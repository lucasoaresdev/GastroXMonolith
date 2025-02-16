using System.ComponentModel.DataAnnotations.Schema;
using Flunt.Notifications;

namespace Domain.Contexts.GlobalContext.ValueObjects;

public abstract class ValueObject : Notifiable<Notification>
{
    [NotMapped]
    public new IReadOnlyCollection<Notification> Notifications => base.Notifications;
}