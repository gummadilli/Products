using Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Products.DBContext
{
    public class DataUow : IDataUoW
    {
        protected DataContext DbContext { get; }
        protected Dictionary<Type, object> Repositories { get; set; }

        protected enum ContextType
        {
            Emp
        }

        public DataUow(DataContext context)
        {
            Repositories = new Dictionary<Type, object>();
            DbContext = context;
        }
        protected IRepository<T> GetStandardRepo<T>(ContextType contextType) where T : class
        {
            if (Repositories.ContainsKey(typeof(T)))
            {
                return (IRepository<T>)Repositories[typeof(T)];
            }
            return MakeRepo<T>(contextType);
        }

        protected IRepository<T> MakeRepo<T>(ContextType contextType) where T : class
        {
            var dataRepo = (contextType == ContextType.Emp) ? new DataRepository<T>(DbContext) : null;
            Repositories[typeof(T)] = dataRepo;
            return dataRepo;
        }

        public async Task<int> CommitAsync(string currentUserName, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await DbContext.SaveChangesAsync(currentUserName, cancellationToken);
        }
        public Task<int> CommitAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return DbContext.SaveChangesAsync(cancellationToken);
        }
        public IRepository<UserProfile> UserProfile => GetStandardRepo<UserProfile>(ContextType.Emp);
        public IRepository<SecretQuestions> SecretQuestions => GetStandardRepo<SecretQuestions>(ContextType.Emp);
        public IRepository<Userdetails> Userdetails => GetStandardRepo<Userdetails>(ContextType.Emp);

        public IRepository<UserAddress> UserAddress => GetStandardRepo<UserAddress>(ContextType.Emp);
        public IRepository<Product> Product => GetStandardRepo<Product>(ContextType.Emp);
        public IRepository<Customers> Customers => GetStandardRepo<Customers>(ContextType.Emp);
        public IRepository<Orders> Orders => GetStandardRepo<Orders>(ContextType.Emp);


    }
}
