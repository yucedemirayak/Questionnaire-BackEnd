using Microsoft.EntityFrameworkCore;
using Questionnaire.Core.IRepositories;
using Questionnaire.Core.Models;
using Questionnaire.Data.Repositories.Base;
using System.Linq.Expressions;

namespace Questionnaire.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private QuestionnaireDbContext Context;
        public UserRepository(QuestionnaireDbContext context) : base(context)
        {
            this.Context = context;
        }

        public async Task<IEnumerable<User>> GetAllWithCompanyDetailsAsync()
        {
            var users = await Context.Users.Select(o => new User()
            {
                Id = o.Id,
                FirstName = o.FirstName,
                LastName = o.LastName,
                Email = o.Email,
                Role = o.Role,
                CreatedTime = o.CreatedTime,
                BirthDate = o.BirthDate,
                CompanyId = o.CompanyId,
                Company = o.Company,
            }).ToListAsync();
            return users;
        }

        public async Task<User> GetByEmailAsync(Expression<Func<User, bool>> predicate) => await Context.Users.AsNoTracking().SingleOrDefaultAsync(predicate);
    }
}
