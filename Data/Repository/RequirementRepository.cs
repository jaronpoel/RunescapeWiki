using Models;
using System;
using Interfaces.Contexts;
using Interfaces.Repositories;

namespace Data.Repositories
{
    public class RequirementRepository : IRequirementRepository
    {
        private readonly IRequirementContext Context;

        public RequirementRepository(IRequirementContext context)
        {
            Context = context;
        }
    }
}
