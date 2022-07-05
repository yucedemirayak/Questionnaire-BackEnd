using Questionnaire.Core;
using Questionnaire.Core.IRepositories;
using Questionnaire.Data.Repositories;

namespace Questionnaire.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly QuestionnaireDbContext context;

        private AdminRepository adminRepository;
        private OptionRepository optionRepository;
        private CompanyRepository companyRepository;
        private ManagerRepository managerRepository;
        private QuestionRepository questionRepository;
        private SurveyRepository surveyRepository;
        private AssignedUserRepository assignedUserRepository;
        private UserAnswerRepository userAnswerRepository;
        private UserRepository userRepository;

        public UnitOfWork(QuestionnaireDbContext _context)
        {
            context = _context;
        }

        public IAdminRepository Admins => adminRepository ?? new AdminRepository(context);
        public IOptionRepository Answers => optionRepository ?? new OptionRepository(context);
        public ICompanyRepository Companies => companyRepository ?? new CompanyRepository(context);
        public IManagerRepository Managers => managerRepository ?? new ManagerRepository(context);
        public IQuestionRepository Questions => questionRepository ?? new QuestionRepository(context);
        public ISurveyRepository Surveys => surveyRepository ?? new SurveyRepository(context);
        public IAssignedUserRepository SurveyUsers => assignedUserRepository ?? new AssignedUserRepository(context);
        public IUserAnswerRepository UserAnswers => userAnswerRepository ?? new UserAnswerRepository(context);
        public IUserRepository Users => userRepository ?? new UserRepository(context);


        public async Task<int> CommitAsync()
        {
            return await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
