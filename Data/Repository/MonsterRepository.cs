using Models;
using System;
using Interfaces.Contexts;
using Interfaces.Repositories;

namespace Data.Repositories
{
    public class MonsterRepository : IMonsterRepository
    {
        private readonly IMonsterContext Context;

        public MonsterRepository(IMonsterContext context)
        {
            Context = context;
        }
        public Monster GetMonsterByID(int id)
        {
            return Context.GetMonsterByID(id);
        }
    }
}
