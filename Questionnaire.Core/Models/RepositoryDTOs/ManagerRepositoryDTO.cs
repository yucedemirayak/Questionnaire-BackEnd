using Questionnaire.Core.Enums;
using System.Text.Json.Serialization;

namespace Questionnaire.Core.Models.RepositoryDTOs
{
    public class ManagerRepositoryDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        [JsonIgnore]
        public string PasswordSalt { get; set; }
        public UserRole Role { get; set; }

        //1-n Relations
        public int CompanyId { get; set; }
        [JsonIgnore]
        public Company Company { get; set; }
    }
}
