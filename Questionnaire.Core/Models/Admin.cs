using Questionnaire.Core.Enums;
using Questionnaire.Core.Models.Base;

namespace Questionnaire.Core.Models
{
    public class Admin : BaseEntity
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public UserRole Role { get; set; }
    }
}
