using Questionnaire.Core.Models.Base;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;


namespace Questionnaire.Core.Models.RepositoryDTOs
{
    public class CompanyRepositoryDTO : BaseEntity
    {
        public CompanyRepositoryDTO()
        {
            Users = new Collection<User>();
            Surveys = new Collection<Survey>();
            Managers = new Collection<Manager>();
        }
        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<User> Users { get; set; }
        [JsonIgnore]
        public ICollection<Survey> Surveys { get; set; }
        [JsonIgnore]
        public ICollection<Manager> Managers { get; set; }
    }
}
