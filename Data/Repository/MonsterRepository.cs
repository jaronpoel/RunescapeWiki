using Models;
using System;
using Interfaces.Contexts;
using Interfaces.Repositories;
using System.Collections.Generic;

namespace Data.Repositories
{
    public class MonsterRepository : IMonsterRepository
    {
        private readonly IMonsterContext Context;

        public MonsterRepository(IMonsterContext context)
        {
            Context = context;
        }

        public List<Monster> GetAllMonsters()
        {
            return Context.GetAllMonsters();
        }

        public Monster GetMonsterByID(int id)
        {
            return Context.GetMonsterByID(id);
        }
    }
}
