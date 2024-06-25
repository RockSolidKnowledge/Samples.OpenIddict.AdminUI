namespace TestService.Models
{
    public record User(string FirstName, string LastName, string UserName, string EmailAddress)
    {

    }

    public static class UserFactory
    {
        private static User BootstrappedUser { get; } = new User("Auto-tests", "System", "tests", "auto.tests.admin@rsk.com");

        public static User CreateUser()
        {
            string firstName = Guid.NewGuid().ToString();
            string lastName = Guid.NewGuid().ToString();
            string userName = Guid.NewGuid().ToString();
            return new User(firstName, lastName, userName, $"{firstName}.{lastName}@abc.com");
        }

        public static User GetTheTestUser()
        {
            return BootstrappedUser;
        }
    }
}
