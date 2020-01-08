using Models;
using System;
using Interfaces.Contexts;
using Interfaces.Repositories;

namespace Data.Repositories
{
    public class TipRepository : ITipRepository
    {
        private readonly ITipContext Context;

        public TipRepository(ITipContext context)
        {
            Context = context;
        }

        public Tip GetTipByMonsterID(int id)
        {
            return Context.GetTipByMonsterID(id);
        }
    }
}
