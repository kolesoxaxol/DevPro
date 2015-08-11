
using DAL;
using Model.Entities;

namespace BusinessLogic.UnitOfWork
{
    public interface IUnitOfWork
    {
        void Dispose();
        void Save();
        GenericRepository<Feed> FeedRepository { get; set; }
        GenericRepository<Resource> ResourceRepository { get; set; }
    }
}
