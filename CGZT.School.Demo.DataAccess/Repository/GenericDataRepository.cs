using AutoMapper;
using CGZT.School.Demo.Contracts.Repository;
using CGZT.School.Demo.DataContext.DemoDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CGZT.School.Demo.DataAccess.Repository
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TM"></typeparam>
    /// <typeparam name="TD"></typeparam>
    public abstract class GenericDataRepository<TM, TD> : IGenericDataRepository<TM, TD>, IDisposable
   where TM : class
   where TD : class
    {
        /// <summary>
        /// The entities
        /// </summary>
        private readonly DemoEntities _entities;
        /// <summary>

        /// <summary>
        /// The disposed
        /// </summary>
        private bool disposed = false;

        protected GenericDataRepository(DemoEntities entities)
        {
            _entities = entities;
        }

        #region Without Async
        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual void Insert(TD entity)
        {
            var item = MapDtoToEntity<TM, TD>(entity);
            _entities.Set<TM>().Add(item);
            Save();
        }

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="returnId">if set to <c>true</c> [return identifier].</param>
        /// <param name="returnName">Name of the return.</param>
        /// <returns></returns>
        public virtual int Insert(TD entity, bool returnId, string returnName)
        {
            var item = MapDtoToEntity<TM, TD>(entity);
            _entities.Set<TM>().Add(item);
            Save();
            return returnId ? (int)item.GetType().GetProperty(returnName).GetValue(item, null) : 0;
        }

        /// <summary>
        /// Adds the get identifier.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public virtual TD InsertModel(TD entity)
        {
            var item = MapDtoToEntity<TM, TD>(entity);
            _entities.Set<TM>().Add(item);
            Save();
            return MapEntityToDto<TM, TD>(item);

        }

        /// <summary>
        /// Edits the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual void Update(TD entity)
        {
            var participationDto = MapEntityToDto<TD, TM>(entity);
            _entities.Set<TM>().Attach(participationDto);
            _entities.Entry(participationDto).State = EntityState.Modified;
            Save();
        }

        /// <summary>
        /// Updates the model.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public virtual TD UpdateModel(TD entity)
        {
            var participationDto = MapEntityToDto<TD, TM>(entity);
            _entities.Set<TM>().Attach(participationDto);
            _entities.Entry(participationDto).State = EntityState.Modified;
            Save();
            return MapEntityToDto<TM, TD>(participationDto);
        }


        /// <summary>
        /// Deletes the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        public virtual void Delete(Expression<Func<TM, bool>> predicate)
        {
            _entities.Set<TM>().RemoveRange(_entities.Set<TM>().Where(predicate));
            Save();
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public virtual List<TD> GetAll()
        {
            var query = _entities.Set<TM>().ToList();
            return MapToDtoList<TM, TD>(query).ToList();
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <param name="mapReset">if set to <c>true</c> [map reset].</param>
        /// <returns></returns>
        public virtual List<TD> GetAll(Expression<Func<TM, int>> expression)
        {
            var entity = _entities.Set<TM>();
            var query = entity.OrderByDescending(expression).ToList();


            return MapToDtoList<TM, TD>(query).ToList();
        }

        /// <summary>
        /// Finds the by.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <param name="mapReset">if set to <c>true</c> [map reset].</param>
        /// <returns></returns>
        public List<TD> FindBy(Expression<Func<TM, bool>> predicate)
        {
            var ent = _entities.Set<TM>();
            var query = ent.Where(predicate).ToList();


            return MapToDtoList<TM, TD>(query).ToList();
        }

        /// <summary>
        /// Singles the or default.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        public TD SingleOrDefault(Expression<Func<TM, bool>> predicate)
        {
            var ent = _entities.Set<TM>();
            var query = ent.AsNoTracking().SingleOrDefault(predicate);

            if (query == null)
                return null;

            return MapEntityToDto<TM, TD>(query);
        }
        /// <summary>
        /// Anies the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        public bool Any(Expression<Func<TM, bool>> predicate)
        {
            var result = _entities.Set<TM>().Any(predicate);
            return result;
        }
        /// <summary>
        /// Saves this instance.
        /// </summary>
        public virtual void Save()
        {
            _entities.SaveChanges();
        }
        #endregion

        #region Async
        /// <summary>
        /// Adds the get identifier asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public virtual async Task<TD> InsertModelAsync(TD entity)
        {
            var item = MapDtoToEntity<TM, TD>(entity);
            _entities.Set<TM>().Add(item);
            await SaveAsync();
            return MapEntityToDto<TM, TD>(item);
        }


        /// <summary>
        /// Updates the model asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public virtual async Task<TD> UpdateModelAsync(TD entity)
        {
            var participationDto = MapEntityToDto<TD, TM>(entity);
            _entities.Set<TM>().Attach(participationDto);
            _entities.Entry(participationDto).State = EntityState.Modified;
            await SaveAsync();
            return MapEntityToDto<TM, TD>(participationDto);
        }

        /// <summary>
        /// Singles the or default asynchronous.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        public async Task<TD> SingleOrDefaultAsync(Expression<Func<TM, bool>> predicate)
        {
            var ent = _entities.Set<TM>();
            var query = await ent.AsNoTracking().SingleOrDefaultAsync(predicate);
            if (query == null)
                return null;
            return MapEntityToDto<TM, TD>(query);
        }

        /// <summary>
        /// Anies the asynchronous.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        public async Task<bool> AnyAsync(Expression<Func<TM, bool>> predicate)
        {
            var result = await _entities.Set<TM>().AnyAsync(predicate);
            return result;
        }

        /// <summary>
        /// Gets all asynchronous.
        /// </summary>
        /// <returns></returns>
        public virtual async Task<List<TD>> GetAllAsync()
        {
            var query = await _entities.Set<TM>().ToListAsync();
            return MapToDtoList<TM, TD>(query).ToList();
        }


        /// <summary>
        /// Deletes the asyn.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        public virtual async Task<int> DeleteAsyn(Expression<Func<TM, bool>> predicate)
        {
            _entities.Set<TM>().RemoveRange(_entities.Set<TM>().Where(predicate));
            return await SaveAsync();
        }

        /// <summary>
        /// Saves the asynchronous.
        /// </summary>
        /// <returns></returns>
        public async virtual Task<int> SaveAsync()
        {
            return await _entities.SaveChangesAsync();
        }
        #endregion

        #region Mapper Resolver
        /// <summary>
        /// Maps to dto list.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <typeparam name="TDto">The type of the dto.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public virtual IEnumerable<TDto> MapToDtoList<TEntity, TDto>(IEnumerable<TEntity> entity)
            where TEntity : class
            where TDto : class
        {

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TEntity, TDto>();
            });

            IMapper mapper = config.CreateMapper();
            return mapper.Map<IEnumerable<TEntity>, IEnumerable<TDto>>(entity);
        }

        /// <summary>
        /// Maps to entity list.
        /// </summary>
        /// <typeparam name="TDto">The type of the dto.</typeparam>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="dto">The dto.</param>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> MapToEntityList<TDto, TEntity>(IEnumerable<TDto> dto)
            where TDto : class
            where TEntity : class
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TDto, TEntity>();
            });

            IMapper mapper = config.CreateMapper();
            return mapper.Map<IEnumerable<TDto>, IEnumerable<TEntity>>(dto);

        }

        /// <summary>
        /// Maps the dto to entity.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <typeparam name="TDto">The type of the dto.</typeparam>
        /// <param name="dto">The dto.</param>
        /// <returns></returns>
        public virtual TEntity MapDtoToEntity<TEntity, TDto>(TDto dto)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TDto, TEntity>().ReverseMap();
            });

            IMapper mapper = config.CreateMapper();
            return mapper.Map<TDto, TEntity>(dto);
        }

        /// <summary>
        /// Maps the entity to dto.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <typeparam name="TDto">The type of the dto.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public virtual TDto MapEntityToDto<TEntity, TDto>(TEntity entity)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TEntity, TDto>();
            });

            IMapper mapper = config.CreateMapper();
            return mapper.Map<TEntity, TDto>(entity);
        }
        #endregion

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _entities.Dispose();
                }
                this.disposed = true;
            }
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

}
