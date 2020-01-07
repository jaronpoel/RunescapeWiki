using Interfaces.Logic;
using Models;


namespace Interfaces.Contexts
{
    /// <summary>
    /// Defines functionality for a user context.
    /// </summary>
    public interface IUserContext : ILogic<User>
    {
        User AuthenticatUser(string Username, string Password);
        User UpdateUser(User user);
        User GetUserByID(int id);
    }
}