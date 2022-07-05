
using Microsoft.EntityFrameworkCore;
using Questionnaire.Core.Models;
using Questionnaire.Core.Models.N2N;

namespace Questionnaire.Data
{
    public class QuestionnaireDbContext : DbContext
    {
        public QuestionnaireDbContext(DbContextOptions<QuestionnaireDbContext> options) : base(options) { }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<AssignedUser> AssignedUsers { get; set; }
        public DbSet<UserAnswer> UserAnswers { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
