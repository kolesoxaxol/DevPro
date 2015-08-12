using System;
using System.Collections.Generic;
using BusinessLogic.IServices;
using BusinessLogic.UnitOfWork;
using Model.Entities;

namespace BusinessLogic.Services
{
    public class FeedService : IFeedService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FeedService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void New(Feed feed)
        {

            if (feed == null)
            {

                throw new ArgumentNullException("feed is null");

            }

            _unitOfWork.FeedRepository.Insert(feed);
            _unitOfWork.Save();

        }

        public void Update(Feed feed)
        {

            if (feed == null)
            {
                throw new ArgumentNullException("feed is null");
            }
            _unitOfWork.FeedRepository.Update(feed);

            _unitOfWork.Save();

        }

        public bool Delete(Feed feed)
        {
            if (feed == null)
            {
                throw new ArgumentNullException("feed is null");
            }
            _unitOfWork.FeedRepository.Delete(feed);

            _unitOfWork.Save();
            return true;
        }
        
        public Feed GetById(int id)
        {
            if (id < 0)
            {
                throw new ArgumentNullException("id is not correct");
            }
            return _unitOfWork.FeedRepository.GetById(id);
        }

        public IEnumerable<Feed> GetAllItems()
        {
            return _unitOfWork.FeedRepository.Get(x => true);
        }
    }
}
