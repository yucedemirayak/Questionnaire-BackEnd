using Questionnaire.Core.IRepositories;

namespace Questionnaire.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IAdminRepository Admins { get; }
        IOptionRepository Answers { get; }
        ICompanyRepository Companies { get; }
        IManagerRepository Managers { get; }
        IQuestionRepository Questions { get; }
        ISurveyRepository Surveys { get; }
        IAssignedUserRepository SurveyUsers { get; }
        IUserAnswerRepository UserAnswers { get; }
        IUserRepository Users { get; }


        Task<int> CommitAsync();
    }
}
