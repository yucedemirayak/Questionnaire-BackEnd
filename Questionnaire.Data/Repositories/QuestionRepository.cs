using Questionnaire.Core.IRepositories;
using Questionnaire.Core.Models;
using Questionnaire.Data.Repositories.Base;

namespace Questionnaire.Data.Repositories
{
    public class QuestionRepository : BaseRepository<Question>, IQuestionRepository
    {
        private readonly QuestionnaireDbContext Context;
        public QuestionRepository(QuestionnaireDbContext context) : base(context)
        {
            this.Context = context;
        }
    }
}
