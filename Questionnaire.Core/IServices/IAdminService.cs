using Questionnaire.Core.IServices.Base;
using Questionnaire.Core.Models;

namespace Questionnaire.Core.IServices
{
    public interface IAdminService : IBaseService<Admin>
    {
        Task<Admin> ReceiveByEmail(string email);
    }
}
