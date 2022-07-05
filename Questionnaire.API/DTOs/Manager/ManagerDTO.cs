using Questionnaire.Core.Models;

namespace Questionnaire.API.DTOs.Manager
{
    public class ManagerDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int CompanyId { get; set; }
    }
}
