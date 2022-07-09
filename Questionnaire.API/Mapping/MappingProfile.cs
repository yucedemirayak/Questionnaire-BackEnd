using AutoMapper;
using Questionnaire.API.DTOs.Admin;
using Questionnaire.API.DTOs.AssignUser;
using Questionnaire.API.DTOs.Company;
using Questionnaire.API.DTOs.Manager;
using Questionnaire.API.DTOs.Option;
using Questionnaire.API.DTOs.Question;
using Questionnaire.API.DTOs.Survey;
using Questionnaire.API.DTOs.User;
using Questionnaire.API.DTOs.UserAnswer;
using Questionnaire.Core.Models;
using Questionnaire.Core.Models.N2N;

namespace Questionnaire.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Resource
            CreateMap<Admin, AdminDTO>();
            CreateMap<Admin, SaveAdminDTO>();

            CreateMap<Company, CompanyDTO>();
            CreateMap<Company, CompanyNameDTO>();

            CreateMap<Manager, ManagerDTO>();
            CreateMap<Manager, SaveManagerDTO>();

            CreateMap<Survey, SurveyDTO>();

            CreateMap<Question, QuestionDTO>();

            CreateMap<User, UserDTO>();
            CreateMap<User, SaveUserDTO>();

            CreateMap<Option, OptionDTO>();

            CreateMap<AssignedUser, AssignedUserDTO>();

            CreateMap<UserAnswer, UserAnswerDTO>();


            // Resource to Domain
            CreateMap<AdminDTO, Admin>();
            CreateMap<SaveAdminDTO, Admin>();

            CreateMap<CompanyDTO, Company>();
            CreateMap<CompanyNameDTO, Company>();

            CreateMap<ManagerDTO, Manager>();
            CreateMap<SaveManagerDTO, Manager>();

            CreateMap<SurveyDTO, Survey>();

            CreateMap<QuestionDTO, Question>();

            CreateMap<UserDTO, User>();
            CreateMap<SaveUserDTO, User>();

            CreateMap<OptionDTO, Option>();

            CreateMap<AssignedUserDTO, AssignedUser>();

            CreateMap<UserAnswerDTO, UserAnswer>();
        }
    }
}
