using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CGZT.School.Demo.Contracts.Repository
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TM"></typeparam>
    /// <typeparam name="TD"></typeparam>
    public interface IGenericDataRepository<TM, TD>
        where TM : class
        where TD : class
    {
        #region Without Async
        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Insert(TD entity);

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="returnId">if set to <c>true</c> [return identifier].</param>
        /// <param name="returnName">Name of the return.</param>
        /// <returns></returns>
        int Insert(TD entity, bool returnId, string returnName);

        /// <summary>
        /// Adds the get identifier.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        TD InsertModel(TD entity);

        /// <summary>
        /// Edits the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Update(TD entity);

        /// <summary>
        /// Updates the model.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        TD UpdateModel(TD entity);

        /// <summary>
        /// Deletes the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        void Delete(Expression<Func<TM, bool>> predicate);

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <param name="mapReset">if set to <c>true</c> [map reset].</param>
        /// <returns></returns>
        List<TD> GetAll(Expression<Func<TM, int>> expression);
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        List<TD> GetAll();

        /// <summary>
        /// Finds the by.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <param name="mapReset">if set to <c>true</c> [map reset].</param>
        /// <returns></returns>
        List<TD> FindBy(Expression<Func<TM, bool>> predicate);

        /// <summary>
        /// Singles the or default.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        TD SingleOrDefault(Expression<Func<TM, bool>> predicate);

        /// <summary>
        /// Anies the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        bool Any(Expression<Func<TM, bool>> predicate);

        /// <summary>
        /// Saves this instance.
        /// </summary>
        void Save();

        #endregion

        #region Async

        /// <summary>
        /// Adds the get identifier asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        Task<TD> InsertModelAsync(TD entity);

        /// <summary>
        /// Updates the model asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        Task<TD> UpdateModelAsync(TD entity);
        /// <summary>
        /// Anies the asynchronous.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        Task<bool> AnyAsync(Expression<Func<TM, bool>> predicate);

        /// <summary>
        /// Gets all asynchronous.
        /// </summary>
        /// <returns></returns>
        Task<List<TD>> GetAllAsync();

        /// <summary>
        /// Singles the or default asynchronous.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        Task<TD> SingleOrDefaultAsync(Expression<Func<TM, bool>> predicate);

        /// <summary>
        /// Deletes the asyn.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        Task<int> DeleteAsyn(Expression<Func<TM, bool>> predicate);

        /// <summary>
        /// Saves the asynchronous.
        /// </summary>
        /// <returns></returns>
        Task<int> SaveAsync();

        #endregion
    }

}
