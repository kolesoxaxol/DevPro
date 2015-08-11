using System;
using DAL;
using Model.Entities;

namespace BusinessLogic.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NewsAggregatorContext _context;
        private GenericRepository<Feed> _feedRepository;
        private GenericRepository<Resource> _resourceRepository;

        public UnitOfWork(NewsAggregatorContext context)
        {
            _context = context;          
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();

                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        public GenericRepository<Feed> FeedRepository
        {
            get { return _feedRepository ?? (_feedRepository = new GenericRepository<Feed>(_context)); }
            set
            {
                _feedRepository = value;
            }
        }

        public GenericRepository<Resource> ResourceRepository
        {
            get { return _resourceRepository ?? (_resourceRepository = new GenericRepository<Resource>(_context)); }
            set
            {
                _resourceRepository = value;
            }
        }
    }
}
