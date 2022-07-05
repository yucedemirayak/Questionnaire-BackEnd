using Questionnaire.Core.IServices.Base;
using Questionnaire.Core.Models;

namespace Questionnaire.Core.IServices
{
    public interface IUserService : IBaseService<User>
    {
        Task<User> ReceiveByEmail(string email);
        Task<IEnumerable<User>> ReceiveAllWithCompanyDetails();
    }
}
