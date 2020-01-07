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
    }
}
