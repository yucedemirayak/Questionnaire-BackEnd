using Microsoft.EntityFrameworkCore;
using Questionnaire.Core.IRepositories;
using Questionnaire.Core.Models;
using Questionnaire.Data.Repositories.Base;

namespace Questionnaire.Data.Repositories
{
    public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
        private readonly QuestionnaireDbContext Context;
        public CompanyRepository(QuestionnaireDbContext context) : base(context)
        {
            this.Context = context;
        }

        public async Task<IEnumerable<Company>> GetAllWithDetailsAsync()
        {
            var companies = await Context.Companies.
                Select(o => new Company()
                {
                    Id = o.Id,
                    Name = o.Name,
                    CreatedTime = o.CreatedTime,
                    Managers = o.Managers.Select(y => new Manager() 
                        {   Id = y.Id,
                            FirstName = y.FirstName, 
                            LastName = y.LastName,
                            Email = y.Email,
                            Role = y.Role,
                            CreatedTime = y.CreatedTime,
                        }).ToList(),
                    Surveys = o.Surveys.Select(x => new Survey() 
                        { 
                            Id = x.Id,
                            Title = x.Title, 
                            Questions = x.Questions.Select(c => new Question() 
                            { 
                                Id = c.Id, 
                                CreatedTime = c.CreatedTime, 
                                Options = c.Options, 
                                QuestionType = c.QuestionType,
                                Title = c.Title,
                            }).ToList() }).ToList(),
                    Users = o.Users.Select(c => new User() 
                    { 
                        Id = c.Id,
                        FirstName = c.FirstName,
                        LastName = c.LastName,
                        Email = c.Email,
                        BirthDate = c.BirthDate,
                        Role = c.Role,
                        CreatedTime = c.CreatedTime,
                    }).ToList(),
                }).ToListAsync();
            return companies;
        }
    }
}
