namespace Questionnaire.API.DTOs.UserAnswer
{
    public struct UserAnswerDTO
    {
        public string? AnswerValue { get; set; }
        public int OptionId { get; set; }
        public int UserId { get; set; }
    }
}
