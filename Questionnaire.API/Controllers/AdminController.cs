using AutoMapper;
using eCommerce.Api.Validations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Questionnaire.API.DTOs;
using Questionnaire.API.DTOs.Admin;
using Questionnaire.API.DTOs.AssignUser;
using Questionnaire.API.DTOs.Company;
using Questionnaire.API.DTOs.Manager;
using Questionnaire.API.DTOs.Option;
using Questionnaire.API.DTOs.Question;
using Questionnaire.API.DTOs.Survey;
using Questionnaire.API.DTOs.User;
using Questionnaire.API.DTOs.UserAnswer;
using Questionnaire.API.Validations.Manager;
using Questionnaire.API.Validations.User;
using Questionnaire.Core.Models;
using Questionnaire.Core.Models.N2N;

namespace Questionnaire.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  //  [Authorize(AuthenticationSchemes = "Bearer", Policy = "AdminPolicy")]

    public class AdminController : Controller
    {
        private readonly Core.IServiceProvider serviceProvider;
        private readonly IMapper mapper;

        public AdminController(Core.IServiceProvider _serviceProvider, IMapper _mapper)
        {
            serviceProvider = _serviceProvider;
            mapper = _mapper;
        }

        //Create a new admin
        [HttpPost("newAdmin")]
        public async Task<ActionResult<AdminDTO>> PostAdmin([FromBody] SaveAdminDTO admin)
        {
            var validator = new SaveAdminDTOValidator();
            var validationResult = await validator.ValidateAsync(admin);

            if (!validationResult.IsValid)
                return BadRequest(ResponseDTO.GenerateResponse(null, false, validationResult.Errors.ToString()));

            var createdAdmin = mapper.Map<SaveAdminDTO, Admin>(admin);
            var addedAdmin = await serviceProvider.AdminServices.Create(createdAdmin);

            var adminDTO = mapper.Map<Admin, AdminDTO>(addedAdmin);

            return Ok(ResponseDTO.GenerateResponse(adminDTO));
        }

        //Delete Company
        [HttpDelete("deleteAdmin")]
        public async Task<ActionResult<ResponseDTO>> DeleteAdmin(int id)
        {
            var deletedAdmin = await serviceProvider.AdminServices.DeleteById(id);
            return Ok(ResponseDTO.GenerateResponse(deletedAdmin));
        }

        //Create new Company
        [HttpPost("newCompany")]
        public async Task<ActionResult<CompanyDTO>> PostUser([FromBody] CompanyDTO company)
        {
            var createdCompany = mapper.Map<CompanyDTO, Company>(company);
            var addedCompany = await serviceProvider.CompanyServices.Create(createdCompany);
            var companyDTO = mapper.Map<Company, CompanyDTO>(createdCompany);

            return Ok(ResponseDTO.GenerateResponse(companyDTO));
        }

        //Get Company Name By ID
        [HttpGet("getCompanyNameById")]
        public async Task<ActionResult<CompanyNameDTO>> GetCompanyById(int id)
        {
            var company = await serviceProvider.CompanyServices.ReceiveById(id);
            var companyNameDTO = mapper.Map<Company, CompanyNameDTO>(company);
            return (Ok(ResponseDTO.GenerateResponse(companyNameDTO)));
        }

        // Get CompanyNames
        [HttpGet("getCompanyNames")]
        public async Task<ActionResult<IEnumerable<CompanyDTO>>> GetCompanyNames()
        {
            var companies = await serviceProvider.CompanyServices.ReceiveAll();
            var companyNames = new List<CompanyDTO>();
            foreach (var company in companies)
            {
                var companyDTO = mapper.Map<Company, CompanyDTO>(company);
                companyNames.Add(companyDTO);
            };

            return Ok(ResponseDTO.GenerateResponse(companyNames));
        }

        //Get Companies With Details
        [HttpGet("getCompaniesWithDetails")]
        public async Task<ActionResult<IEnumerable<Company>>> GetCompanyDetails()
        {
            var companyDTOs = await serviceProvider.CompanyServices.ReceiveAllWithDetails();
            return Ok(ResponseDTO.GenerateResponse(companyDTOs));
        }

        //Delete Company
        [HttpDelete("deleteCompany")]
        public async Task<ActionResult<ResponseDTO>> DeleteCompany(int id)
        {
            var deletedCompany = await serviceProvider.CompanyServices.DeleteById(id);
            return Ok(ResponseDTO.GenerateResponse(deletedCompany));
        }

        //Create new Manager
        [HttpPost("newManager")]
        public async Task<ActionResult<ManagerDTO>> PostManager([FromBody] SaveManagerDTO manager)
        {
            var validator = new SaveManagerDTOValidator();
            var validationResult = await validator.ValidateAsync(manager);

            if (!validationResult.IsValid)
                return BadRequest(ResponseDTO.GenerateResponse(null, false, validationResult.Errors.ToString()));

            var createdManager = mapper.Map<SaveManagerDTO, Manager>(manager);
            var addedManager = await serviceProvider.ManagerServices.Create(createdManager);

            var managerDTO = mapper.Map<Manager, ManagerDTO>(addedManager);

            return Ok(ResponseDTO.GenerateResponse(managerDTO));
        }

        //Get Managers With Company Details
        [HttpGet("getManagersWithCompanyDetails")]
        public async Task<ActionResult<Manager>> GetManagersWithCompanyDetails()
        {
            var managers = await serviceProvider.ManagerServices.ReceiveAllWithCompanyDetails();
            return Ok(ResponseDTO.GenerateResponse(managers));
        }

        //Delete Company
        [HttpDelete("deleteManager")]
        public async Task<ActionResult<ResponseDTO>> DeleteManager(int id)
        {
            var deletedManager = await serviceProvider.ManagerServices.DeleteById(id);
            return Ok(ResponseDTO.GenerateResponse(deletedManager));
        }

        //Create new user
        [HttpPost("newUser")]
        public async Task<ActionResult<UserDTO>> PostUser([FromBody] SaveUserDTO user)
        {
            var validator = new SaveUserDTOValidator();
            var validationResult = await validator.ValidateAsync(user);

            if (!validationResult.IsValid)
                return BadRequest(ResponseDTO.GenerateResponse(null, false, validationResult.Errors.ToString()));

            var createdUser = mapper.Map<SaveUserDTO, User>(user);
            var addedUser = await serviceProvider.UserServices.Create(createdUser);

            var userDTO = mapper.Map<User, UserDTO>(addedUser);

            return Ok(ResponseDTO.GenerateResponse(userDTO));
        }

        //Get all users list
        [HttpGet("getUsers")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAllUsers()
        {
            var users = await serviceProvider.UserServices.ReceiveAll();
            var userDTOs = mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(users);
            return Ok(ResponseDTO.GenerateResponse(userDTOs));
        }

        //Get all users with Company Details
        [HttpGet("getUsersWithCompanyDetails")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAllUsersWithCompanyDetails()
        {
            var users = await serviceProvider.UserServices.ReceiveAllWithCompanyDetails();
            return Ok(ResponseDTO.GenerateResponse(users));
        }

        //Delete Company
        [HttpDelete("deleteUser")]
        public async Task<ActionResult<ResponseDTO>> DeleteUser(int id)
        {
            var deletedUser = await serviceProvider.UserServices.DeleteById(id);
            return Ok(ResponseDTO.GenerateResponse(deletedUser));
        }


        ///////////////////////////////////////////////////////////////////////////////

        //Create Survey
        [HttpPost("createSurvey")]
        public async Task<ActionResult<SurveyDTO>> CreateSurvey(SurveyDTO newSurvey)
        {
            var createdSurvey = mapper.Map<SurveyDTO, Survey>(newSurvey);
            var addedSurvey = await serviceProvider.SurveyServices.Create(createdSurvey);
            var surveyDTO = mapper.Map<Survey, SurveyDTO>(addedSurvey);
            return Ok(ResponseDTO.GenerateResponse(surveyDTO));
        }

        // Get Survey
        [HttpGet("GetSurveysWithOptions")]
        public async Task<ActionResult<Survey>> GetSurveysWithOptions()
        {
            var surveys = await serviceProvider.SurveyServices.ReceiveAllWithOptions();
            return Ok(ResponseDTO.GenerateResponse(surveys));        
        }

        //Delete Survey
        [HttpDelete("deleteSurvey")]
        public async Task<ActionResult<ResponseDTO>> DeleteSurvey(int id)
        {
            var deletedSurvey = await serviceProvider.SurveyServices.DeleteById(id);
            return Ok(ResponseDTO.GenerateResponse(deletedSurvey));
        }

        //Create Question
        [HttpPost("createQuestion")]
        public async Task<ActionResult<QuestionDTO>> CreateQuestion(QuestionDTO newQuestion)
        {
            var createdQuestions = mapper.Map<QuestionDTO, Question>(newQuestion);
            var addedQuestion = await serviceProvider.QuestionServices.Create(createdQuestions);
            var questionDTO = mapper.Map<Question, QuestionDTO>(addedQuestion);
            return Ok(ResponseDTO.GenerateResponse(questionDTO));
        }

        //Add Options to Question
        [HttpPost("addOptions")]
        public async Task<ActionResult<OptionDTO>> AddOptions(OptionDTO newOption)
        {
            var createdOption = mapper.Map<OptionDTO, Option>(newOption);
            var addedOption = await serviceProvider.OptionServices.Create(createdOption);
            var optionDTO = mapper.Map<Option, OptionDTO>(addedOption);
            return Ok(ResponseDTO.GenerateResponse(optionDTO));
        }

        // Assign User's To Survey
        [HttpPost("assignUser")]
        public async Task<ActionResult<AssignedUserDTO>> AssignUser(AssignedUserDTO assignedUser)
        {
            var createdAssignedUser = mapper.Map<AssignedUserDTO, AssignedUser>(assignedUser);
            var addedAssignedUser = await serviceProvider.AssignedUserServices.Create(createdAssignedUser);
            var assignedUserDTO = mapper.Map<AssignedUser, AssignedUserDTO>(addedAssignedUser);
            return Ok(ResponseDTO.GenerateResponse(assignedUserDTO));
        }

        // Answer Question
        [HttpPost("answerQuestion")]
        public async Task<ActionResult<UserAnswerDTO>> CreateAnswer(UserAnswerDTO userAnswer)
        {
            var createdUserAnswer = mapper.Map<UserAnswerDTO, UserAnswer>(userAnswer);
            var addedAssignedUser = await serviceProvider.UserAnswerServices.Create(createdUserAnswer);
            var userAnswerDTO = mapper.Map<UserAnswer, UserAnswerDTO>(addedAssignedUser);
            return Ok(ResponseDTO.GenerateResponse(userAnswerDTO));
        }
    }
}
