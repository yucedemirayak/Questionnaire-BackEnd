using Questionnaire.Core.Models.Base;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace Questionnaire.Core.Models
{
    public class Survey : BaseEntity
    {
        public Survey()
        {
            Questions = new Collection<Question>();
        }
        public string Title { get; set; }

        //1-n Relations
        public int CompanyId { get; set; }
        public Company Company { get; set; }

        //n-1 Relations
        public ICollection<Question> Questions { get; set; }
    }
}