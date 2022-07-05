using Questionnaire.Core;
using Questionnaire.Core.Enums;
using Questionnaire.Core.Helpers;
using Questionnaire.Core.IServices;
using Questionnaire.Core.Models;

namespace Questionnaire.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;
        public UserService(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public async Task<User> ChangeById(int id, User updatedUser)
        {
            var existingUser = await ReceiveById(id);

            if (!BCrypt.Net.BCrypt.Verify(updatedUser.Password + existingUser.PasswordSalt, existingUser.Password))
            {
                updatedUser.PasswordSalt = PasswordHelper.GenerateSalt();
                updatedUser.Password = PasswordHelper.HashPassword(updatedUser.Password, updatedUser.PasswordSalt);
            }

            await unitOfWork.Users.UpdateByIdAsync(id, updatedUser);
            await unitOfWork.CommitAsync();
            return await ReceiveById(id);
        }

        public async Task<User> ChangeValueById(int id, object value, string propName)
        {
            var existingUser = await ReceiveById(id);

            if (propName == "Password")
            {
                if (existingUser == null)
                {
                    throw new ArgumentOutOfRangeException("Entity Id:" + id + " not found.");
                }
                var newPassword = value.GetType().GetProperty("Value").GetValue(value).ToString();

                if (!BCrypt.Net.BCrypt.Verify(newPassword + existingUser.PasswordSalt, existingUser.Password))
                {
                    string newHashedPassword = PasswordHelper.HashPassword(newPassword, existingUser.PasswordSalt);
                    await unitOfWork.Users.UpdateValueByIdAsync(id, newHashedPassword, propName);
                }
            }
            else
            {
                await unitOfWork.Users.UpdateValueByIdAsync(id, value, propName);
            }

            await unitOfWork.CommitAsync();
            return await ReceiveById(id);
        }

        public async Task<User> Create(User newUser)
        {
            newUser.Role = UserRole.USER;
            newUser.PasswordSalt = PasswordHelper.GenerateSalt();
            newUser.Password = PasswordHelper.HashPassword(newUser.Password, newUser.PasswordSalt);
            await unitOfWork.Users.AddAsync(newUser);
            await unitOfWork.CommitAsync();
            return newUser;
        }

        public async Task<User> DeleteById(int id)
        {
            var deletedUser = await ReceiveById(id);
            unitOfWork.Users.Remove(deletedUser);
            await unitOfWork.CommitAsync();
            return deletedUser;
        }

        public async Task<User> ReceiveByEmail(string email)
        {
            return await unitOfWork.Users.GetByEmailAsync(x => x.Email == email);
        }

        public async Task<IEnumerable<User>> ReceiveAll()
        {
            return await unitOfWork.Users.GetAllAsync();
        }

        public async Task<User> ReceiveById(int id)
        {
            return await unitOfWork.Users.GetByIdAsync(id);
        }

        public async Task<IEnumerable<User>> ReceiveAllWithCompanyDetails()
        {
            return await unitOfWork.Users.GetAllWithCompanyDetailsAsync();
        }
    }
}