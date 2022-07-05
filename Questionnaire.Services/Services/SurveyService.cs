using Questionnaire.Core;
using Questionnaire.Core.Enums;
using Questionnaire.Core.Helpers;
using Questionnaire.Core.IServices;
using Questionnaire.Core.Models;

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
            var deletedSurvey = await ReceiveById(id);
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
