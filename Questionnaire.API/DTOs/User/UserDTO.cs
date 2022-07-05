using System.ComponentModel.DataAnnotations;

namespace Questionnaire.API.DTOs.User
{
    public struct UserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }
        public int CompanyId { get; set; }
    }
}
