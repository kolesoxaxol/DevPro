using System;
using System.Collections.Generic;
using BusinessLogic.IServices;
using BusinessLogic.UnitOfWork;
using Model.Entities;

namespace BusinessLogic.Services
{
    public class ResourceService : IResourceService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ResourceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void New(Resource resource)
        {
            if (resource == null)
            {
                throw new ArgumentNullException("resource is null");
            }

            _unitOfWork.ResourceRepository.Insert(resource);
            _unitOfWork.Save();
        }

        public void Update(Resource resource)
        {
            if (resource == null)
            {
                throw new ArgumentNullException("resource is null");
            }
            _unitOfWork.ResourceRepository.Update(resource);
            _unitOfWork.Save();
        }

        public bool Delete(Resource resource)
        {
            if (resource == null)
            {
                throw new ArgumentNullException("resource is null");
            }
            _unitOfWork.ResourceRepository.Delete(resource);
            _unitOfWork.Save();
            return true;
        }

        public Resource GetById(int id)
        {
            if (id < 0)
            {
                throw new Exception("id is not correct");
            }
            return _unitOfWork.ResourceRepository.GetById(id);
        }

        public IEnumerable<Resource> GetAllItems()
        {
            return _unitOfWork.ResourceRepository.Get(x => true);
        }
    }
}
