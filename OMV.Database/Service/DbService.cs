using AutoMapper;
using OMV.Video.Database.Contexts;
using System.Linq.Expressions;

namespace OMV.Video.Database.Service
{
    //public class DbService<T>
    //{
    //    public T? Data { get; set; }
    //    public bool Sucess { get; set; } = true;
    //    public string Message { get; set; } = string.Empty;
    //}

    public class DbService : IDbService
    {
        private readonly OMVContext _db;
        private readonly IMapper _mapper;

        public DbService(OMVContext context, IMapper mapper)
        {
            _db = context;
            _mapper = mapper;
        }


        //Hämta in alla och lägg i lista
        public async Task<List<TDto>> GetAllAsync<TEntity, TDto>()
        where TEntity : class, IEntity
        where TDto : class
        {
            var entities = await _db.Set<TEntity>().ToListAsync();
            return _mapper.Map<List<TDto>>(entities);
        }




        //Hämta in alla och lägg i lista som uppfyller sök-kriteriet
        public async Task<List<TDto>> GetAllAsync<TEntity, TDto>(Expression<Func<TEntity, bool>> expression)
            where TEntity : class, IEntity
            where TDto : class
        {
            var entities = await _db.Set<TEntity>().Where(expression).ToListAsync();
            return _mapper.Map<List<TDto>>(entities);
        }

        //Används i funktioner nedan för att göra om DTOn till en Entity och returnera ut den
        private async Task<TEntity?> SingleAsync<TEntity>(Expression<Func<TEntity, bool>> expression)
            where TEntity : class, IEntity => await _db.Set<TEntity>().SingleOrDefaultAsync(expression);

        //
        public async Task<TDto> SingleAsync<TEntity, TDto>(Expression<Func<TEntity, bool>> expression)
            where TEntity : class, IEntity
             where TDto : class
        {
            var entity = await SingleAsync(expression);
            return _mapper.Map<TDto>(entity);
        }

        public void Include<TEntity>()
        where TEntity : class, IEntity
        {
            var propertyNames = _db.Model.FindEntityType(typeof(TEntity))?.GetNavigations().Select(x => x.Name);

            if (propertyNames is null) return;

            foreach (var name in propertyNames)
                _db.Set<TEntity>().Include(name).Load();
        }

        public void IncludeRef<TReferenceEntity>()
        where TReferenceEntity : class, IReferenceEntity
        {
            var propertyNames = _db.Model.FindEntityType(typeof(TReferenceEntity))?.GetNavigations().Select(x => x.Name);

            if (propertyNames is null) return;

            foreach (var name in propertyNames)
                _db.Set<TReferenceEntity>().Include(name).Load();
        }

        public async Task<bool> AnyAsync<TEntity>(Expression<Func<TEntity, bool>> expression)
            where TEntity : class, IEntity => await _db.Set<TEntity>().AnyAsync(expression);


        public async Task<bool> SaveChangesAsync() => await _db.SaveChangesAsync() >= 0;

        public async Task<TEntity> AddAsync<TEntity, TDto>(TDto dto)
            where TEntity : class, IEntity
            where TDto : class
        {
            var entity = _mapper.Map<TEntity>(dto);
            await _db.Set<TEntity>().AddAsync(entity);
            return entity;
        }



        public async Task<TReferenceEntity> AddAsyncRefEntity<TReferenceEntity, TDto>(TDto dto)
            where TReferenceEntity : class, IReferenceEntity
            where TDto : class
        {
            var entity = _mapper.Map<TReferenceEntity>(dto);
            await _db.Set<TReferenceEntity>().AddAsync(entity);
            return entity;
        }

        public void Update<TEntity, TDto>(int id, TDto dto)
             where TEntity : class, IEntity
             where TDto : class
        {
            var entity = _mapper.Map<TEntity>(dto);
            entity.Id = id;
            _db.Set<TEntity>().Update(entity);
        }

        public async Task<bool> DeleteAsync<TEntity>(int id)
            where TEntity : class, IEntity

        {
            try
            {
                var entity = await SingleAsync<TEntity>(e => e.Id.Equals(id));
                if (entity == null)
                {
                    return false;
                }
                _db.Remove(entity);
            }
            catch
            {
                throw;
            }
            return true;
        }


        public bool DeleteAsyncRefEntity<TReferenceEntity, TDto>(TDto dto)
            where TReferenceEntity : class
            where TDto : class
        {
            try
            {
                var entity = _mapper.Map<TReferenceEntity>(dto);
                if (entity == null)
                {
                    return false;
                }
                _db.Remove(entity);
            }
            catch
            {
                throw;
            }
            return true;
        }
        public string GetURL<TEntity>(TEntity entity) where TEntity : class, IEntity
            => $"/{typeof(TEntity).Name.ToLower()}s/{entity.Id}";

        public string GetURLRef<TReferenceEntity, TDto>(TDto dto) where TReferenceEntity : class, IReferenceEntity
            => $"/{typeof(IReferenceEntity).Name.ToLower()}s/{dto}";


    }


}
