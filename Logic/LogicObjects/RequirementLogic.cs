using Data.Repositories;
using Interfaces.Contexts;
using Interfaces.Repositories;

namespace Logic.LogicObjects
{
    public class RequirementLogic : IRequirementLogic
    {
        private readonly IRequirementRepository RequirementRepository;

        public RequirementLogic(IRequirementContext context)
        {
            RequirementRepository = new RequirementRepository(context);
        }

    }
}
