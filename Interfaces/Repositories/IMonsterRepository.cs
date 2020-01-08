using Models;
using System.Collections.Generic;

namespace Interfaces.Repositories
{
    /// <summary>
    /// Defines functionality for a user context.
    /// </summary>
    public interface IMonsterRepository : IRepository<Monster>
    {
        List<Monster> GetAllMonsters();
        Monster GetMonsterByID(int id);
    }
}