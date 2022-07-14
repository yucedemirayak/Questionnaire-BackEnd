using Questionnaire.Core;
using Questionnaire.Core.Enums;
using Questionnaire.Core.Helpers;
using Questionnaire.Core.IServices;
using Questionnaire.Core.Models;
using Questionnaire.Core.Models.N2N;

namespace Questionnaire.Services.Services
{
    public class AssignedUserService : IAssignedUserService
    {
        private readonly IUnitOfWork unitOfWork;
        public AssignedUserService(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public async Task<AssignedUser> ChangeById(int id, AssignedUser entity)
        {
            await unitOfWork.AssignedUsers.UpdateByIdAsync(id, entity);
            await unitOfWork.CommitAsync();
            return await ReceiveById(id);
        }

        public async Task<AssignedUser> ChangeValueById(int id, object value, string propName)
        {
            await unitOfWork.AssignedUsers.UpdateValueByIdAsync(id, value, propName);
            await unitOfWork.CommitAsync();
            return await ReceiveById(id);
        }

        public async Task<AssignedUser> Create(AssignedUser entity)
        {
            await unitOfWork.AssignedUsers.AddAsync(entity);
            await unitOfWork.CommitAsync();
            return entity;
        }

        public async Task<AssignedUser> DeleteById(int id)
        {
            var deletedEntity = await ReceiveById(id);
            unitOfWork.AssignedUsers.Remove(deletedEntity);
            await unitOfWork.CommitAsync();
            return deletedEntity;
        }

        public async Task<IEnumerable<AssignedUser>> ReceiveAll()
        {
            return await unitOfWork.AssignedUsers.GetAllAsync();
        }

        public async Task<AssignedUser> ReceiveById(int id)
        {
            return await unitOfWork.AssignedUsers.GetByIdAsync(id);
        }
    }
}
