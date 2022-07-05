using Questionnaire.Core.Enums;
using Questionnaire.Core.Models.Base;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace Questionnaire.Core.Models
{
    public class Company : BaseEntity
    {
        public Company()
        {
            Users = new Collection<User>();
            Surveys = new Collection<Survey>();
            Managers = new Collection<Manager>();
        }
        public string Name { get; set; }

        //n-1 Relations
        public ICollection<User> Users { get; set; }
        public ICollection<Survey> Surveys { get; set; }
        public ICollection<Manager> Managers { get; set; }
    }
}
