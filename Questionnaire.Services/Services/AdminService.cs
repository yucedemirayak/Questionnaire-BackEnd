using Questionnaire.Core;
using Questionnaire.Core.Enums;
using Questionnaire.Core.Helpers;
using Questionnaire.Core.IServices;
using Questionnaire.Core.Models;

namespace Questionnaire.Services.Services
{
    public class AdminService : IAdminService
    {
        private readonly IUnitOfWork unitOfWork;
        public AdminService(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }


        public async Task<Admin> Create(Admin newAdmin)
        {
            newAdmin.Role = UserRole.ADMIN;
            newAdmin.PasswordSalt = PasswordHelper.GenerateSalt();
            newAdmin.Password = PasswordHelper.HashPassword(newAdmin.Password, newAdmin.PasswordSalt);
            await unitOfWork.Admins.AddAsync(newAdmin);
            await unitOfWork.CommitAsync();
            return newAdmin;
        }

        public async Task<Admin> DeleteById(int id)
        {
            var deletedAdmin = await ReceiveById(id);
            unitOfWork.Admins.Remove(deletedAdmin);
            await unitOfWork.CommitAsync();
            return deletedAdmin;
        }

        public async Task<IEnumerable<Admin>> ReceiveAll()
        {
            return await unitOfWork.Admins.GetAllAsync();
        }

        public async Task<Admin> ReceiveByEmail(string email)
        {
            return await unitOfWork.Admins.GetByEmailAsync(x => x.Email == email);
        }

        public async Task<Admin> ReceiveById(int id)
        {
            return await unitOfWork.Admins.GetByIdAsync(id);
        }

        public async Task<Admin> ChangeById(int id, Admin updatedAdmin)
        {
            var existingAdmin = await ReceiveById(id);

            if (!BCrypt.Net.BCrypt.Verify(updatedAdmin.Password + existingAdmin.PasswordSalt, existingAdmin.Password))
            {
                updatedAdmin.PasswordSalt = PasswordHelper.GenerateSalt();
                updatedAdmin.Password = PasswordHelper.HashPassword(updatedAdmin.Password, updatedAdmin.PasswordSalt);
            }

            await unitOfWork.Admins.UpdateByIdAsync(id, updatedAdmin);
            await unitOfWork.CommitAsync();
            return await ReceiveById(id);
        }

        public async Task<Admin> ChangeValueById(int id, object value, string propName)
        {
            var existingAdmin = await ReceiveById(id);

            if (propName == "Password")
            {
                if (existingAdmin == null)
                {
                    throw new ArgumentOutOfRangeException("Entity Id:" + id + " not found.");
                }
                var newPassword = value.GetType().GetProperty("Value").GetValue(value).ToString();

                if (!BCrypt.Net.BCrypt.Verify(newPassword + existingAdmin.PasswordSalt, existingAdmin.Password))
                {
                    string newHashedPassword = PasswordHelper.HashPassword(newPassword, existingAdmin.PasswordSalt);
                    await unitOfWork.Admins.UpdateValueByIdAsync(id, newHashedPassword, propName);
                }
            }
            else
            {
                await unitOfWork.Admins.UpdateValueByIdAsync(id, value, propName);
            }

            await unitOfWork.CommitAsync();
            return await ReceiveById(id);
        }

    }
}