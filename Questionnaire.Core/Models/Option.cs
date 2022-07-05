using Questionnaire.Core.Enums;
using Questionnaire.Core.Models.Base;
using System.Text.Json.Serialization;

namespace Questionnaire.Core.Models
{
    public class Option : BaseEntity
    {
        public string Text { get; set; }

        //1-n Relations
        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
