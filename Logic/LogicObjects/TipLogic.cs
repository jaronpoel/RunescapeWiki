using Data.Repositories;
using Interfaces.Contexts;
using Interfaces.Repositories;

namespace Logic.LogicObjects
{
    public class TipLogic: ITipLogic
    {
        private readonly ITipRepository TipRepository;

        public TipLogic(ITipContext context)
        {
            TipRepository = new TipRepository(context);
        }

    }
}
