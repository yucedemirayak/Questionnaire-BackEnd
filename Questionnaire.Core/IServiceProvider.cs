using Questionnaire.Core.IServices;

namespace Questionnaire.Core
{
    public interface IServiceProvider
    {
        IAdminService AdminServices { get; }
        IOptionService OptionServices { get; }
        ICompanyService CompanyServices { get; }
        IManagerService ManagerServices { get; }
        IQuestionService QuestionServices { get; }
        ISurveyService SurveyServices { get; }
        IAssignedUserService AssignedUserServices { get; }
        IUserAnswerService UserAnswerServices { get; }
        IUserService UserServices { get; }
    }
}
