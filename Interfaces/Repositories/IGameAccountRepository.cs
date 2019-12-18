using Models;


namespace Interfaces.Repositories
{
    /// <summary>
    /// Defines functionality for a user context.
    /// </summary>
    public interface IGameAccountRepository : IRepository<GameAccount>
    {
        GameAccount GetAccountByID(int id);
    }
}