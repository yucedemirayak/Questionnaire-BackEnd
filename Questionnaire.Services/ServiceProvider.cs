using Questionnaire.Core;
using Questionnaire.Core.IServices;
using Questionnaire.Services.Services;

namespace Questionnaire.Services
{
    public class ServiceProvider : Core.IServiceProvider
    {
        private readonly IUnitOfWork unitOfWork;

        private AdminService adminService;
        private OptionService optionService;
        private CompanyService companyService;
        private ManagerService managerService;
        private QuestionService questionService;
        private SurveyService surveyService;
        private AssignedUserService assignedUserService;
        private UserAnswerService userAnswerService;
        private UserService userService;

        public ServiceProvider(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public IAdminService AdminServices => adminService ?? new AdminService(unitOfWork);
        public IOptionService OptionServices => optionService ?? new OptionService(unitOfWork);
        public ICompanyService CompanyServices => companyService ?? new CompanyService(unitOfWork);
        public IManagerService ManagerServices => managerService ?? new ManagerService(unitOfWork);
        public IQuestionService QuestionServices => questionService ?? new QuestionService(unitOfWork);
        public ISurveyService SurveyServices => surveyService ?? new SurveyService(unitOfWork);
        public IAssignedUserService AssignedUserServices => assignedUserService ?? new AssignedUserService(unitOfWork);
        public IUserAnswerService UserAnswerServices => userAnswerService ?? new UserAnswerService(unitOfWork);
        public IUserService UserServices => userService ?? new UserService(unitOfWork);
    }
}
