using Questionnaire.Core.Enums;

namespace Questionnaire.API.DTOs.Question
{
    public struct QuestionDTO
    {
        public string Title { get; set; }
        public QuestionType QuestionType { get; set; }
        public int SurveyId { get; set; }
    }
}
