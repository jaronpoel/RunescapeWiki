using Data.Repositories;
using Interfaces.Contexts;
using Interfaces.Repositories;
using Models;

namespace Logic.LogicObjects
{
    public class TipLogic: ITipLogic
    {
        private readonly ITipRepository TipRepository;

        public TipLogic(ITipContext context)
        {
            TipRepository = new TipRepository(context);
        }

        public Tip GetTipByMonsterID(int id)
        {
            return TipRepository.GetTipByMonsterID(id);
        }
    }
}
