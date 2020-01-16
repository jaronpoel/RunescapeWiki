using Models;


namespace Interfaces.Repositories
{
    /// <summary>
    /// Defines functionality for a user context.
    /// </summary>
    public interface IUserRepository : IRepository<User>
    {
        User AuthenticatUser(string Username, string Password);
        User UpdateUser(User user);
        User GetUserByID(int id);
        void InsertUser(User user);
    }
}