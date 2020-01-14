using Models;
using System;
using Interfaces.Contexts;
using Interfaces.Repositories;

namespace Data.Repositories
{
    public class GameAccountRepository : IGameAccountRepository
    {
        private readonly IGameAccountContext Context;

        public GameAccountRepository(IGameAccountContext context)
        {
            Context = context;
        }

        public GameAccount GetAccountByID(int id)
        {
            return Context.GetAccountByID(id);
        }

        public GameAccount UpdateStats(GameAccount account)
        {
            return Context.UpdateStats(account);
        }
    }
}
