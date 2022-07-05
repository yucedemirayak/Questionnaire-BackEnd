using Questionnaire.Core.IRepositories;
using Questionnaire.Core.Models.N2N;
using Questionnaire.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.Data.Repositories
{
    public class UserAnswerRepository : BaseRepository<UserAnswer>, IUserAnswerRepository
    {
        private readonly QuestionnaireDbContext Context;
        public UserAnswerRepository(QuestionnaireDbContext context) : base(context)
        {
            this.Context = context;
        }
    }
}
