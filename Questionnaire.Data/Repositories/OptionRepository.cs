using Questionnaire.Core.IRepositories;
using Questionnaire.Core.Models;
using Questionnaire.Data.Repositories.Base;

namespace Questionnaire.Data.Repositories
{
    public class OptionRepository : BaseRepository<Option>, IOptionRepository
    {
        private readonly QuestionnaireDbContext Context;
        public OptionRepository(QuestionnaireDbContext context) : base(context)
        {
            this.Context = context;
        }
    }
}
