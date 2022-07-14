using Questionnaire.Core;
using Questionnaire.Core.Enums;
using Questionnaire.Core.Helpers;
using Questionnaire.Core.IServices;
using Questionnaire.Core.Models;
using Questionnaire.Core.Models.N2N;

namespace Questionnaire.Services.Services
{
    public class SurveyService : ISurveyService
    {
        private readonly IUnitOfWork unitOfWork;
        public SurveyService(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public async Task<Survey> ChangeById(int id, Survey survey)
        {
            await unitOfWork.Surveys.UpdateByIdAsync(id, survey);
            await unitOfWork.CommitAsync();
            return await ReceiveById(id);
        }

        public async Task<Survey> ChangeValueById(int id, object value, string propName)
        {
            await unitOfWork.Surveys.UpdateValueByIdAsync(id, value, propName);
            await unitOfWork.CommitAsync();
            return await ReceiveById(id);
        }

        public async Task<Survey> Create(Survey survey)
        {
            await unitOfWork.Surveys.AddAsync(survey);
            await unitOfWork.CommitAsync();
            return survey;
        }

        public async Task<Survey> DeleteById(int id)
        {
            //FIXME: infinite loop while deleting
            var deletedSurvey = await ReceiveById(id);
            var deletedAssignedUsers = await unitOfWork.AssignedUsers.GetRange(x => x.SurveyId == deletedSurvey.Id);
            var deletedQuestions = await unitOfWork.Questions.GetRange(x => x.SurveyId == deletedSurvey.Id);
            var allDeletedOptions = new List<Option> ();
            var allDeletedUserAnswers = new List<UserAnswer>();
            foreach (var question in deletedQuestions)
            {
                var deletedOptions = await unitOfWork.Options.GetRange(x => x.QuestionId == question.Id);
                allDeletedOptions.AddRange(deletedOptions);
            }
            foreach (var option in allDeletedOptions)
            {
                var deletedUserAnswers = await unitOfWork.UserAnswers.GetRange(x => x.OptionId == option.Id);
                allDeletedUserAnswers.AddRange(deletedUserAnswers);
            }
            unitOfWork.AssignedUsers.RemoveRange(deletedAssignedUsers);
            unitOfWork.UserAnswers.RemoveRange(allDeletedUserAnswers);
            unitOfWork.Options.RemoveRange(allDeletedOptions);
            unitOfWork.Questions.RemoveRange(deletedQuestions);
            unitOfWork.Surveys.Remove(deletedSurvey);
            await unitOfWork.CommitAsync();
            return deletedSurvey;
        }

        public async Task<IEnumerable<Survey>> ReceiveAll()
        {
            return await unitOfWork.Surveys.GetAllAsync();
        }

        public async Task<IEnumerable<Survey>> ReceiveAllWithOptions()
        {
            return await unitOfWork.Surveys.GetAllWithOptionsAsync();
        }

        public async Task<Survey> ReceiveById(int id)
        {
            return await unitOfWork.Surveys.GetByIdAsync(id);
        }

    }
}
