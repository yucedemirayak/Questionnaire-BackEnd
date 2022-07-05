

namespace Questionnaire.Core.IServices.Base
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> ReceiveAll();
        Task<TEntity> ReceiveById(int id);
        Task<TEntity> DeleteById(int id);
        Task<TEntity> Create(TEntity entity);
        Task<TEntity> ChangeById(int id, TEntity entity);
        Task<TEntity> ChangeValueById(int id, object value, string propName);
    }
}
