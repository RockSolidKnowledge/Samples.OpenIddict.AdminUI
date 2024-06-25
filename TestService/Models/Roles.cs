namespace TestService.Models
{
    public record Role(string Name, string Description)
    {

    }

    public static class RoleFactory
    {
        public static Role Create()
        {
            Guid roleId = Guid.NewGuid();

            return new Role($"Role {roleId}", $"Role {roleId} description");
        }

        public static string GetAdministratorRoleName()
        {
            return " AdminUI Administrator ";
        }
    }
}
