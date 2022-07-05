using Questionnaire.Core.IRepositories;
using Questionnaire.Core.Models;
using Questionnaire.Data.Repositories.Base;

namespace Questionnaire.Data.Repositories
{
    public class SurveyRepository : BaseRepository<Survey>, ISurveyRepository
    {
        private readonly QuestionnaireDbContext Context;
        public SurveyRepository(QuestionnaireDbContext context) : base(context)
        {
            this.Context = context;
        }

        public async Task<IEnumerable<Survey>> GetAllWithOptionsAsync()
        {
            var surveys = Context.Surveys.Select(o => new Survey() 
            {
                Id = o.Id,
                Title = o.Title,
                CreatedTime = o.CreatedTime,
                CompanyId = o.CompanyId,
                Company = o.Company,
                Questions = o.Questions.Select(x => new Question() 
                    {
                        Id = x.Id,
                        Title = x.Title,
                        QuestionType = x.QuestionType,
                        SurveyId = x.SurveyId,
                        CreatedTime = x.CreatedTime,
                        Options = x.Options.Select(y => new Option() 
                            {
                                Id = y.Id,
                                Text = y.Text,
                                QuestionId = y.QuestionId,
                                CreatedTime = y.CreatedTime
                            }).ToList()
                    }).ToList(),
            }).ToList();

            return surveys;
        }
    }
}
