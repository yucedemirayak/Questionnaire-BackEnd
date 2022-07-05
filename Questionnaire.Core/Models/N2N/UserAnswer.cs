using Questionnaire.Core.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Questionnaire.Core.Models.N2N
{
    public class UserAnswer : BaseEntity
    {
        public string? AnswerValue { get; set; }

        [ForeignKey("OptionId")]
        public int? OptionId { get; set; }
        public Option Option { get; set; }

        [ForeignKey("UserId")]
        public int? UserId { get; set; }
        public User User { get; set; }
    }
}
