using Questionnaire.Core.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Questionnaire.Core.Models.N2N
{
    public class AssignedUser : BaseEntity
    {
        [ForeignKey("SurveyId")]
        public int? SurveyId { get; set; }
        public Survey Survey { get; set; }

        [ForeignKey("UserId")]
        public int? UserId { get; set; }
        public User User { get; set; }
    }
}
