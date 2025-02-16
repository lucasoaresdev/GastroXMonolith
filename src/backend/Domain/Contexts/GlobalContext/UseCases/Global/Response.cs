using Flunt.Notifications;

namespace Domain.Contexts.GlobalContext.UseCases;

public abstract class Response
{
    public string Message { get; set; } = string.Empty;
    public int Status { get; set; } = 400;
    public bool IsSucess => Status is >= 200 and <= 299;
    public IEnumerable<Notification>? Notifications { get; set; }
}