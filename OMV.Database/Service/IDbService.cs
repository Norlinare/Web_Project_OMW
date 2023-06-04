using System.Linq.Expressions;

namespace OMV.Video.Database.Service
{
    public interface IDbService
    {
        Task<TEntity> AddAsync<TEntity, TDto>(TDto dto)
            where TEntity : class, IEntity
            where TDto : class;

        Task<TReferenceEntity> AddAsyncRefEntity<TReferenceEntity, TDto>(TDto dto)
            where TReferenceEntity : class, IReferenceEntity
            where TDto : class;

        Task<bool> AnyAsync<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class, IEntity;

        Task<bool> DeleteAsync<TEntity>(int id) where TEntity : class, IEntity;

        bool DeleteAsyncRefEntity<TReferenceEntity, TDto>(TDto dto)
            where TReferenceEntity : class
            where TDto : class;

        Task<List<TDto>> GetAllAsync<TEntity, TDto>()
            where TEntity : class, IEntity
            where TDto : class;

        Task<List<TDto>> GetAllAsync<TEntity, TDto>(Expression<Func<TEntity, bool>> expression)
            where TEntity : class, IEntity
            where TDto : class;

        string GetURL<TEntity>(TEntity entity) where TEntity : class, IEntity;

        string GetURLRef<TReferenceEntity, TDto>(TDto dto) where TReferenceEntity : class, IReferenceEntity;

        void Include<TEntity>() where TEntity : class, IEntity;

        void IncludeRef<TReferenceEntity>() where TReferenceEntity : class, IReferenceEntity;

        Task<bool> SaveChangesAsync();

        Task<TDto> SingleAsync<TEntity, TDto>(Expression<Func<TEntity, bool>> expression)
            where TEntity : class, IEntity
            where TDto : class;

        void Update<TEntity, TDto>(int id, TDto dto)
            where TEntity : class, IEntity
            where TDto : class;
    }
}