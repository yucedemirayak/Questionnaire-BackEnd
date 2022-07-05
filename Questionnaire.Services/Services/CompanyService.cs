using Questionnaire.Core;
using Questionnaire.Core.IServices;
using Questionnaire.Core.Models;

namespace Questionnaire.Services.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IUnitOfWork unitOfWork;
        public CompanyService(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public async Task<Company> ChangeById(int id, Company company)
        {
            await unitOfWork.Companies.UpdateByIdAsync(id, company);
            await unitOfWork.CommitAsync();
            return await ReceiveById(id);
        }

        public async Task<Company> ChangeValueById(int id, object value, string propName)
        {
            await unitOfWork.Companies.UpdateValueByIdAsync(id, value, propName);
            await unitOfWork.CommitAsync();
            return await ReceiveById(id);
        }

        public async Task<Company> Create(Company company)
        {
            await unitOfWork.Companies.AddAsync(company);
            await unitOfWork.CommitAsync();
            return company;
        }

        public async Task<Company> DeleteById(int id)
        {
            var deletedCompany = await ReceiveById(id);
            var deletedManagers = await unitOfWork.Managers.GetRange(x => x.CompanyId == deletedCompany.Id);
            unitOfWork.Managers.RemoveRange(deletedManagers);
            await unitOfWork.CommitAsync();
            unitOfWork.Companies.Remove(deletedCompany);
            await unitOfWork.CommitAsync();
            return deletedCompany;
        }

        public async Task<IEnumerable<Company>> ReceiveAll()
        {
            return await unitOfWork.Companies.GetAllAsync();
        }

        public async Task<Company> ReceiveById(int id)
        {
            return await unitOfWork.Companies.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Company>> ReceiveAllWithDetails()
        {
            return await unitOfWork.Companies.GetAllWithDetailsAsync();
        }
    }
}
