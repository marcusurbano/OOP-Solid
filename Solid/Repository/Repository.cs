using Solid.Repository.Mock;
using System;

namespace Solid.Repository
{
    public class Repository : IRepository
    {
        public IContext DbContext { get; set; }

        private Repository()
        {

        }

        public Repository(IContext dbContext)
        {
            DbContext = dbContext;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                DbContext.Dispose();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
