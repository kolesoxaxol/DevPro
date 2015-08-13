using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Model.Entities;

namespace BusinessLogic.IServices
{
    public interface IResourceService : IGenericService<Resource>
    {
        void GetFeedList(Resource resource);
    }
}
