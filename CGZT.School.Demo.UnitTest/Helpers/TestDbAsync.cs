using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CGZT.School.Demo.UnitTest.Helpers
{

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <seealso cref="System.Data.Entity.Infrastructure.IDbAsyncQueryProvider" />
    internal class TestDbAsyncQueryProvider<TEntity> : IDbAsyncQueryProvider
    {
        /// <summary>
        /// The inner
        /// </summary>
        private readonly IQueryProvider _inner;

        /// <summary>
        /// Initializes a new instance of the <see cref="TestDbAsyncQueryProvider{TEntity}"/> class.
        /// </summary>
        /// <param name="inner">The inner.</param>
        internal TestDbAsyncQueryProvider(IQueryProvider inner)
        {
            _inner = inner;
        }

        /// <summary>
        /// Constructs an <see cref="T:System.Linq.IQueryable" /> object that can evaluate the query represented by a specified expression tree.
        /// </summary>
        /// <param name="expression">An expression tree that represents a LINQ query.</param>
        /// <returns>
        /// An <see cref="T:System.Linq.IQueryable" /> that can evaluate the query represented by the specified expression tree.
        /// </returns>
        public IQueryable CreateQuery(Expression expression)
        {
            return new TestDbAsyncEnumerable<TEntity>(expression);
        }

        /// <summary>
        /// Constructs an <see cref="T:System.Linq.IQueryable`1" /> object that can evaluate the query represented by a specified expression tree.
        /// </summary>
        /// <typeparam name="TElement">The type of the elements of the <see cref="T:System.Linq.IQueryable`1" /> that is returned.</typeparam>
        /// <param name="expression">An expression tree that represents a LINQ query.</param>
        /// <returns>
        /// An <see cref="T:System.Linq.IQueryable`1" /> that can evaluate the query represented by the specified expression tree.
        /// </returns>
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            return new TestDbAsyncEnumerable<TElement>(expression);
        }

        /// <summary>
        /// Executes the query represented by a specified expression tree.
        /// </summary>
        /// <param name="expression">An expression tree that represents a LINQ query.</param>
        /// <returns>
        /// The value that results from executing the specified query.
        /// </returns>
        public object Execute(Expression expression)
        {
            return _inner.Execute(expression);
        }

        /// <summary>
        /// Executes the strongly-typed query represented by a specified expression tree.
        /// </summary>
        /// <typeparam name="TResult">The type of the value that results from executing the query.</typeparam>
        /// <param name="expression">An expression tree that represents a LINQ query.</param>
        /// <returns>
        /// The value that results from executing the specified query.
        /// </returns>
        public TResult Execute<TResult>(Expression expression)
        {
            return _inner.Execute<TResult>(expression);
        }

        /// <summary>
        /// Asynchronously executes the query represented by a specified expression tree.
        /// </summary>
        /// <param name="expression">An expression tree that represents a LINQ query.</param>
        /// <param name="cancellationToken">A <see cref="T:System.Threading.CancellationToken" /> to observe while waiting for the task to complete.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains the value that results from executing the specified query.
        /// </returns>
        public Task<object> ExecuteAsync(Expression expression, CancellationToken cancellationToken)
        {
            return Task.FromResult(Execute(expression));
        }

        /// <summary>
        /// Asynchronously executes the strongly-typed query represented by a specified expression tree.
        /// </summary>
        /// <typeparam name="TResult">The type of the value that results from executing the query.</typeparam>
        /// <param name="expression">An expression tree that represents a LINQ query.</param>
        /// <param name="cancellationToken">A <see cref="T:System.Threading.CancellationToken" /> to observe while waiting for the task to complete.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains the value that results from executing the specified query.
        /// </returns>
        public Task<TResult> ExecuteAsync<TResult>(Expression expression, CancellationToken cancellationToken)
        {
            return Task.FromResult(Execute<TResult>(expression));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="System.Linq.EnumerableQuery{T}" />
    /// <seealso cref="System.Data.Entity.Infrastructure.IDbAsyncEnumerable{T}" />
    /// <seealso cref="System.Linq.IQueryable{T}" />
    internal class TestDbAsyncEnumerable<T> : EnumerableQuery<T>, IDbAsyncEnumerable<T>, IQueryable<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestDbAsyncEnumerable{T}"/> class.
        /// </summary>
        /// <param name="enumerable">A collection to associate with the new instance.</param>
        public TestDbAsyncEnumerable(IEnumerable<T> enumerable)
            : base(enumerable)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TestDbAsyncEnumerable{T}"/> class.
        /// </summary>
        /// <param name="expression">An expression tree to associate with the new instance.</param>
        public TestDbAsyncEnumerable(Expression expression)
            : base(expression)
        { }

        /// <summary>
        /// Gets an enumerator that can be used to asynchronously enumerate the sequence.
        /// </summary>
        /// <returns>
        /// Enumerator for asynchronous enumeration over the sequence.
        /// </returns>
        public IDbAsyncEnumerator<T> GetAsyncEnumerator()
        {
            return new TestDbAsyncEnumerator<T>(this.AsEnumerable().GetEnumerator());
        }

        /// <summary>
        /// Gets an enumerator that can be used to asynchronously enumerate the sequence.
        /// </summary>
        /// <returns>
        /// Enumerator for asynchronous enumeration over the sequence.
        /// </returns>
        IDbAsyncEnumerator IDbAsyncEnumerable.GetAsyncEnumerator()
        {
            return GetAsyncEnumerator();
        }

        /// <summary>
        /// Gets the query provider that is associated with this data source.
        /// </summary>
        IQueryProvider IQueryable.Provider
        {
            get { return new TestDbAsyncQueryProvider<T>(this); }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="System.Data.Entity.Infrastructure.IDbAsyncEnumerator{T}" />
    internal class TestDbAsyncEnumerator<T> : IDbAsyncEnumerator<T>
    {
        /// <summary>
        /// The inner
        /// </summary>
        private readonly IEnumerator<T> _inner;

        /// <summary>
        /// Initializes a new instance of the <see cref="TestDbAsyncEnumerator{T}"/> class.
        /// </summary>
        /// <param name="inner">The inner.</param>
        public TestDbAsyncEnumerator(IEnumerator<T> inner)
        {
            _inner = inner;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            _inner.Dispose();
        }

        /// <summary>
        /// Advances the enumerator to the next element in the sequence, returning the result asynchronously.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="T:System.Threading.CancellationToken" /> to observe while waiting for the task to complete.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains true if the enumerator was successfully advanced to the next element; false if the enumerator has passed the end of the sequence.
        /// </returns>
        public Task<bool> MoveNextAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(_inner.MoveNext());
        }

        /// <summary>
        /// Gets the current element in the iteration.
        /// </summary>
        public T Current
        {
            get { return _inner.Current; }
        }

        /// <summary>
        /// Gets the current element in the iteration.
        /// </summary>
        object IDbAsyncEnumerator.Current
        {
            get { return Current; }
        }
    }

}
