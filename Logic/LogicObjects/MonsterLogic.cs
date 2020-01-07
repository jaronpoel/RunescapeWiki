using Data.Repositories;
using Interfaces.Contexts;
using Interfaces.Repositories;

namespace Logic.LogicObjects
{
    public class MonsterLogic: IMonsterLogic
    {
        private readonly IMonsterRepository MonsterRepository;

        public MonsterLogic(IMonsterContext context)
        {
            MonsterRepository = new MonsterRepository(context);
        }

    }
}
