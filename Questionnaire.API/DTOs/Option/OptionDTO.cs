using Questionnaire.Core.Enums;

namespace Questionnaire.API.DTOs.Option
{
    public struct OptionDTO
    {
        public string Text { get; set; }
        public int QuestionId { get; set; }
    }
}
