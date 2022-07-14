using Questionnaire.Core.IRepositories;

namespace Questionnaire.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IAdminRepository Admins { get; }
        IOptionRepository Options { get; }
        ICompanyRepository Companies { get; }
        IManagerRepository Managers { get; }
        IQuestionRepository Questions { get; }
        ISurveyRepository Surveys { get; }
        IAssignedUserRepository AssignedUsers { get; }
        IUserAnswerRepository UserAnswers { get; }
        IUserRepository Users { get; }


        Task<int> CommitAsync();
    }
}
