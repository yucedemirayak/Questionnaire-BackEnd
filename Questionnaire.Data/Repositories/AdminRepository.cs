using Microsoft.EntityFrameworkCore;
using Questionnaire.Core.IRepositories;
using Questionnaire.Core.Models;
using Questionnaire.Data.Repositories.Base;
using System.Linq.Expressions;

namespace Questionnaire.Data.Repositories
{
    public class AdminRepository : BaseRepository<Admin>, IAdminRepository
    {
        private readonly QuestionnaireDbContext Context;

        public AdminRepository(QuestionnaireDbContext context) : base(context)
        {
            this.Context = context;
        }
        public async Task<Admin> GetByEmailAsync(Expression<Func<Admin, bool>> predicate) => await Context.Admins.AsNoTracking().SingleOrDefaultAsync(predicate);
    }
}
