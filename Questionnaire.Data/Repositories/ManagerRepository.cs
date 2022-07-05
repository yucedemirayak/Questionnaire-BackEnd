using Microsoft.EntityFrameworkCore;
using Questionnaire.Core.IRepositories;
using Questionnaire.Core.Models;
using Questionnaire.Core.Models.RepositoryDTOs;
using Questionnaire.Data.Repositories.Base;
using System.Linq.Expressions;

namespace Questionnaire.Data.Repositories
{
    public class ManagerRepository : BaseRepository<Manager>, IManagerRepository
    {
        private QuestionnaireDbContext Context;
        public ManagerRepository(QuestionnaireDbContext context) : base(context)
        {
            this.Context = context;
        }

        public async Task<IEnumerable<Manager>> GetAllWithCompanyDetailsAsync()
        {
            var managers = await Context.Managers.Select(o => new Manager() 
            {
                Id = o.Id,
                FirstName = o.FirstName,
                LastName = o.LastName,
                Email = o.Email,
                Role = o.Role,
                CreatedTime = o.CreatedTime,
                CompanyId = o.CompanyId,
                Company = o.Company,
            }).ToListAsync();
            return managers;
        }

        public async Task<Manager> GetByEmailAsync(Expression<Func<Manager, bool>> predicate) => await Context.Managers.AsNoTracking().SingleOrDefaultAsync(predicate);
    }
}
