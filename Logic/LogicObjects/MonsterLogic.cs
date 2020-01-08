using Data.Repositories;
using Interfaces.Contexts;
using Interfaces.Repositories;
using Models;
using System.Collections.Generic;

namespace Logic.LogicObjects
{
    public class MonsterLogic: IMonsterLogic
    {
        private readonly IMonsterRepository MonsterRepository;

        public MonsterLogic(IMonsterContext context)
        {
            MonsterRepository = new MonsterRepository(context);
        }

        public List<Monster> GetAllMonsters()
        {
            return MonsterRepository.GetAllMonsters();
        }

        public Monster GetMonsterByID(int id)
        {
            return MonsterRepository.GetMonsterByID(id);
        }
    }
}
