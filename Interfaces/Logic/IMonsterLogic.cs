using Interfaces.Logic;
using Models;

namespace Interfaces.Contexts
{
    /// <summary>
    /// Defines functionality for a user context.
    /// </summary>
    public interface IMonsterLogic : ILogic<Monster>
    {
        Monster GetMonsterByID(int id);
    }
}