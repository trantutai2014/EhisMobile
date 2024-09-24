using System;
using System.Threading.Tasks;

namespace Data.EF
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> CommitAsync();

        Task BulkSaveChanges();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly MDPDbContext _context;

        public UnitOfWork(MDPDbContext context)
        {
            _context = context;
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task BulkSaveChanges()
        {
             await _context.BulkSaveChangesAsync();
        }

        #region disposed

        private bool disposed = false;

        protected void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion disposed
    }
}
