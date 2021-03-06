using Questionnaire.Core.Enums;
using Questionnaire.Core.Models.Base;
using System.Text.Json.Serialization;

namespace Questionnaire.Core.Models
{
    public class Manager : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        [JsonIgnore]
        public string PasswordSalt { get; set; }
        public UserRole Role{ get; set; }

        //1-n Relations
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
