using Interfaces.Logic;
using Models;


namespace Interfaces.Contexts
{
    /// <summary>
    /// Defines functionality for a user context.
    /// </summary>
    public interface IUserContext : ILogic<User>
    {
        User AuthenticatUser(string email, string password);
        User UpdateUser(User user);
        User GetUserByID(int id);
    }
}