using Flunt.Notifications;

namespace Domain.Contexts.CustomerContext.UseCases.Create;

public class Response : GlobalContext.UseCases.Response
{
    protected Response()
    {

    }

    public Response(
        string message,
        int status,
        IEnumerable<Notification>? notifications = null)
    {
        Message = message;
        Status = status;
        Notifications = notifications;
    }

    public Response(string message)
    {
        Message = message;
        Status = 201;
        Notifications = null;
    }
}