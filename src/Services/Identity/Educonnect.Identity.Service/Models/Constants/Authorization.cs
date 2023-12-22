namespace Educonnect.Identity.Service.API.Models.Constants
{
    public class Authorization
    {
        public enum Roles
        {
            Administrator,
            Moderator,
            User
        }
        public const string default_username = "admin@educonnect.com";
        public const string default_email = "admin@educonnect.com";
        public const string default_password = "P@ssw0rd";
        public const Roles default_role = Roles.User;
    }
}
