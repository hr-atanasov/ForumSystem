using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ForumSystem.Data.Common.Contracts
{
       
    using System;
    using System.Linq;

    public interface IRepository<T> : IDisposable where T : class
    {
        IQueryable<T> All();

        T GetById(int id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Delete(int id);

        void Detach(T entity);
    }
}
