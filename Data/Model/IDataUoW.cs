using Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Products.DBContext
{
        public interface IDataUoW
        {
            Task<int> CommitAsync(CancellationToken cancellationToken = default(CancellationToken));
            Task<int> CommitAsync(string currentUserName, CancellationToken cancellationToken = default(CancellationToken));
            IRepository<UserProfile> UserProfile { get; }
            IRepository<SecretQuestions> SecretQuestions { get; }
            IRepository<Userdetails> Userdetails { get; }
            IRepository<UserAddress> UserAddress { get; }
            IRepository<Product> Product { get; }
            IRepository<Customers> Customers { get; }
            IRepository<Orders> Orders { get; }

    }
    
}
