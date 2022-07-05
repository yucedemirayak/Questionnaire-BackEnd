using Questionnaire.Core;
using Questionnaire.Core.Enums;
using Questionnaire.Core.Helpers;
using Questionnaire.Core.IServices;
using Questionnaire.Core.Models;

namespace Questionnaire.Services.Services
{
    public class OptionService : IOptionService
    {
        private readonly IUnitOfWork unitOfWork;

        public OptionService(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public async Task<Option> ChangeById(int id, Option answer)
        {
            await unitOfWork.Answers.UpdateByIdAsync(id, answer);
            await unitOfWork.CommitAsync();
            return await ReceiveById(id);
        }

        public async Task<Option> ChangeValueById(int id, object value, string propName)
        {
            await unitOfWork.Answers.UpdateValueByIdAsync(id, value, propName);
            await unitOfWork.CommitAsync();
            return await ReceiveById(id);
        }

        public async Task<Option> Create(Option option)
        {
            await unitOfWork.Answers.AddAsync(option);
            await unitOfWork.CommitAsync();
            return option;
        }

        public async Task<Option> DeleteById(int id)
        {
            var deletedAnswer = await ReceiveById(id);
            unitOfWork.Answers.Remove(deletedAnswer);
            await unitOfWork.CommitAsync();
            return deletedAnswer;
        }

        public async Task<IEnumerable<Option>> ReceiveAll()
        {
            return await unitOfWork.Answers.GetAllAsync();
        }

        public async Task<Option> ReceiveById(int id)
        {
            return await unitOfWork.Answers.GetByIdAsync(id);
        }
    }
}