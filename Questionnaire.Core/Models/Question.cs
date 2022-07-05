using Questionnaire.Core.Enums;
using Questionnaire.Core.Models.Base;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace Questionnaire.Core.Models
{
    public class Question : BaseEntity
    {
        public Question()
        {
            Options = new Collection<Option>();
        }
        public string Title { get; set; }
        public QuestionType QuestionType { get; set; }

        //1-n Relations
        public int SurveyId { get; set; }
        public Survey Survey { get; set; }

        //n-1 Relations
        public ICollection<Option> Options { get; set; }
    }
}
