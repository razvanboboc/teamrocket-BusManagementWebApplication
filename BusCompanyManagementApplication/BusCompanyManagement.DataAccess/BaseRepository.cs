using BusCompanyManagement.ApplicationLogic.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusCompanyManagement.DataAccess
{
    public class BaseRepository<T> : IRepository<T>
    {
        protected BusCompanyManagementDbContext dbContext;

        public BaseRepository(BusCompanyManagementDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public T Add(T itemToAdd)
        {
            throw new NotImplementedException();
        }

        public bool Delete(T itemToDelete)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T Update(T itemToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
