using Questionnaire.Core.IServices.Base;
using Questionnaire.Core.Models;

namespace Questionnaire.Core.IServices
{
    public interface IManagerService : IBaseService<Manager>
    {
        Task<Manager> ReceiveByEmail(string email);
        Task<IEnumerable<Manager>> ReceiveAllWithCompanyDetails();
    }
}
