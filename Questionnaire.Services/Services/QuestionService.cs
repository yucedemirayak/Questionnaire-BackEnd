using Questionnaire.Core;
using Questionnaire.Core.Enums;
using Questionnaire.Core.Helpers;
using Questionnaire.Core.IServices;
using Questionnaire.Core.Models;

namespace Questionnaire.Services.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IUnitOfWork unitOfWork;
        public QuestionService(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public async Task<Question> ChangeById(int id, Question question)
        {
            await unitOfWork.Questions.UpdateByIdAsync(id, question);
            await unitOfWork.CommitAsync();
            return await ReceiveById(id);
        }

        public async Task<Question> ChangeValueById(int id, object value, string propName)
        {
            await unitOfWork.Questions.UpdateValueByIdAsync(id, value, propName);
            await unitOfWork.CommitAsync();
            return await ReceiveById(id);
        }

        public async Task<Question> Create(Question question)
        {
            await unitOfWork.Questions.AddAsync(question);
            await unitOfWork.CommitAsync();
            return question;
        }

        public async Task<Question> DeleteById(int id)
        {
            var deletedQuestion = await ReceiveById(id);
            unitOfWork.Questions.Remove(deletedQuestion);
            await unitOfWork.CommitAsync();
            return deletedQuestion;
        }

        public async Task<IEnumerable<Question>> ReceiveAll()
        {
            return await unitOfWork.Questions.GetAllAsync();
        }

        public async Task<Question> ReceiveById(int id)
        {
            return await unitOfWork.Questions.GetByIdAsync(id);
        }
    }
}
