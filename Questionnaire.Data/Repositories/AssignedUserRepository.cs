using Questionnaire.Core.IRepositories;
using Questionnaire.Core.Models.N2N;
using Questionnaire.Data.Repositories.Base;

namespace Questionnaire.Data.Repositories
{
    public class AssignedUserRepository : BaseRepository<AssignedUser>, IAssignedUserRepository
    {
        private readonly QuestionnaireDbContext Context;
        public AssignedUserRepository(QuestionnaireDbContext context) : base(context)
        {
            this.Context = context;
        }
    }
}
