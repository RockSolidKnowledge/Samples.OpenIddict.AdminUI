namespace TestService.Models;

public record Client(string clientId, string displayName, string description)
{

}

public static class ClientFactory
{
    public static Client Create()
    {
        string clientId = Guid.NewGuid().ToString();
        string displayName = Guid.NewGuid().ToString();
        string discretion = Guid.NewGuid().ToString();
        return new Client(clientId, displayName, discretion);
    }
}