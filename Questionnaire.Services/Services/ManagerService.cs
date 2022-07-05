using Questionnaire.Core;
using Questionnaire.Core.Enums;
using Questionnaire.Core.Helpers;
using Questionnaire.Core.IServices;
using Questionnaire.Core.Models;

namespace Questionnaire.Services.Services
{
    public class ManagerService : IManagerService
    {
        private readonly IUnitOfWork unitOfWork;
        public ManagerService(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public async Task<Manager> ChangeById(int id, Manager updatedManager)
        {
            var existingManager = await ReceiveById(id);

            if (!BCrypt.Net.BCrypt.Verify(updatedManager.Password + existingManager.PasswordSalt, existingManager.Password))
            {
                updatedManager.PasswordSalt = PasswordHelper.GenerateSalt();
                updatedManager.Password = PasswordHelper.HashPassword(updatedManager.Password, updatedManager.PasswordSalt);
            }

            await unitOfWork.Managers.UpdateByIdAsync(id, updatedManager);
            await unitOfWork.CommitAsync();
            return await ReceiveById(id);
        }

        public async Task<Manager> ChangeValueById(int id, object value, string propName)
        {
            var existingManager = await ReceiveById(id);

            if (propName == "Password")
            {
                if (existingManager == null)
                {
                    throw new ArgumentOutOfRangeException("Entity Id:" + id + " not found.");
                }
                var newPassword = value.GetType().GetProperty("Value").GetValue(value).ToString();

                if (!BCrypt.Net.BCrypt.Verify(newPassword + existingManager.PasswordSalt, existingManager.Password))
                {
                    string newHashedPassword = PasswordHelper.HashPassword(newPassword, existingManager.PasswordSalt);
                    await unitOfWork.Managers.UpdateValueByIdAsync(id, newHashedPassword, propName);
                }
            }
            else
            {
                await unitOfWork.Managers.UpdateValueByIdAsync(id, value, propName);
            }

            await unitOfWork.CommitAsync();
            return await ReceiveById(id);
        }

        public async Task<Manager> Create(Manager newManager)
        {
            newManager.Role = UserRole.MANAGER;
            newManager.PasswordSalt = PasswordHelper.GenerateSalt();
            newManager.Password = PasswordHelper.HashPassword(newManager.Password, newManager.PasswordSalt);
            await unitOfWork.Managers.AddAsync(newManager);
            await unitOfWork.CommitAsync();
            return newManager;
        }

        public async Task<Manager> DeleteById(int id)
        {
            var deletedManager = await ReceiveById(id);
            unitOfWork.Managers.Remove(deletedManager);
            await unitOfWork.CommitAsync();
            return deletedManager;
        }

        public async Task<IEnumerable<Manager>> ReceiveAll()
        {
            return await unitOfWork.Managers.GetAllAsync();
        }

        public async Task<IEnumerable<Manager>> ReceiveAllWithCompanyDetails()
        {
            return await unitOfWork.Managers.GetAllWithCompanyDetailsAsync();
        }

        public async Task<Manager> ReceiveByEmail(string email)
        {
            return await unitOfWork.Managers.GetByEmailAsync(x => x.Email == email);
        }

        public async Task<Manager> ReceiveById(int id)
        {
            return await unitOfWork.Managers.GetByIdAsync(id);
        }
    }
}
