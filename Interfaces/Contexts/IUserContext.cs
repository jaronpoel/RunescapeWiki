using Models;

namespace Interfaces.Contexts
{
    /// <summary>
    /// Defines functionality for a user context.
    /// </summary>
    public interface IUserContext : ILogic<User>
    {
        void AuthenticatUser(string email, string password);
    }
}