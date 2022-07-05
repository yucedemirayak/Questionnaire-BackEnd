using Microsoft.EntityFrameworkCore;
using Questionnaire.Core.IRepositories.Base;
using System.Linq.Expressions;

namespace Questionnaire.Data.Repositories.Base
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly QuestionnaireDbContext Context;

        public BaseRepository(QuestionnaireDbContext context)
        {
            this.Context = context;
        }

        public async Task AddAsync(TEntity entity)
        {
            await Context.Set<TEntity>().AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities) => await Context.Set<TEntity>().AddRangeAsync(entities);

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate) => Context.Set<TEntity>().AsNoTracking().Where(predicate);

        public async Task<IEnumerable<TEntity>> GetAllAsync() => await Context.Set<TEntity>().ToListAsync();

        public async ValueTask<TEntity> GetByIdAsync(int id) => await Context.Set<TEntity>().FindAsync(id);

        public async Task<IEnumerable<TEntity>> GetRange(Expression<Func<TEntity, bool>> predicate)
        {
            return await Context.Set<TEntity>().AsNoTracking().Where(predicate).ToListAsync();
        }

        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
        }

        public async Task<TEntity> SignleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate) => await Context.Set<TEntity>().SingleOrDefaultAsync(predicate);

        public async Task<TEntity> UpdateByIdAsync(int id, TEntity entity)
        {
            TEntity existingEntity = await GetByIdAsync(id);

            var properties = entity.GetType().GetProperties();

            for (int i = 0; i < properties.Length; i++)
            {
                var value = entity?.GetType()?.GetProperty(properties[i].Name)?.GetValue(entity);

                string[] staticProperties = new string[] { "Id", "CreatedTime" };

                if (!staticProperties.Contains(properties[i].Name))
                {
                    existingEntity?.GetType()?.GetProperty(properties[i].Name)?.SetValue(existingEntity, value);
                }
            }
            Context.Set<TEntity>().Update(existingEntity);
            return existingEntity;
        }

        public async Task<TEntity> UpdateValueByIdAsync(int id, object value, string propName)
        {
            string[] staticProperties = new string[] { "Id", "CreatedTime", "PasswordSalt" };
            if (staticProperties.Contains(propName))
            {
                throw new ArgumentException(propName + " cannot be changed");
            }

            TEntity existingEntity = await GetByIdAsync(id);

            if (existingEntity == null)
            {
                throw new ArgumentOutOfRangeException("Entity Id:" + id + " not found.");
            }

            var property = existingEntity.GetType().GetProperty(propName);
            if (property == null)
            {
                throw new ArgumentOutOfRangeException(propName + " not found");
            }

            if (propName == "Password")
            {
                var newValue = value;
                existingEntity.GetType().GetProperty(propName).SetValue(existingEntity, newValue);
            }
            else
            {
                var newValue = value.GetType().GetProperty("Value").GetValue(value);
                existingEntity.GetType().GetProperty(propName).SetValue(existingEntity, newValue);
            }

            Context.Set<TEntity>().Update(existingEntity);
            return (existingEntity);
        }


    }
}
