using Questionnaire.Core;
using Questionnaire.Core.IServices;
using Questionnaire.Core.Models.N2N;

namespace Questionnaire.Services.Services
{
    public class UserAnswerService : IUserAnswerService
    {
        private readonly IUnitOfWork unitOfWork;
        public UserAnswerService(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public async Task<UserAnswer> ChangeById(int id, UserAnswer entity)
        {
            await unitOfWork.UserAnswers.UpdateByIdAsync(id, entity);
            await unitOfWork.CommitAsync();
            return await ReceiveById(id);
        }

        public async Task<UserAnswer> ChangeValueById(int id, object value, string propName)
        {
            await unitOfWork.UserAnswers.UpdateValueByIdAsync(id, value, propName);
            await unitOfWork.CommitAsync();
            return await ReceiveById(id);
        }

        public async Task<UserAnswer> Create(UserAnswer entity)
        {
            await unitOfWork.UserAnswers.AddAsync(entity);
            await unitOfWork.CommitAsync();
            return entity;
        }

        public async Task<UserAnswer> DeleteById(int id)
        {
            var deletedUserAnswer = await ReceiveById(id);
            unitOfWork.UserAnswers.Remove(deletedUserAnswer);
            await unitOfWork.CommitAsync();
            return deletedUserAnswer;
        }

        public async Task<IEnumerable<UserAnswer>> ReceiveAll()
        {
            return await unitOfWork.UserAnswers.GetAllAsync();
        }

        public async Task<UserAnswer> ReceiveById(int id)
        {
            return await unitOfWork.UserAnswers.GetByIdAsync(id);
        }
    }
}
