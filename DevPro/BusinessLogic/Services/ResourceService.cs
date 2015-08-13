using System;
using System.Collections.Generic;
using System.Linq;
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
            GetFeedList(resource);
            _unitOfWork.ResourceRepository.Insert(resource);
            _unitOfWork.Save();
        }

        public void Update(Resource resource)
        {
            if (resource == null)
            {
                throw new ArgumentNullException("resource is null");
            }
             GetFeedList(resource);
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

        public void GetFeedList(Resource resource)
        {
            if (resource == null)
            {
                throw new ArgumentNullException();
            }

            var htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml(resource.Url);
            var feeds = new List<Feed>();

            HtmlAgilityPack.HtmlNode root = htmlDoc.DocumentNode;

            foreach (HtmlAgilityPack.HtmlNode currentFeed in root.SelectNodes((resource.xPathFeed)))
            {
                var feed = new Feed();

                var body = currentFeed.SelectNodes(resource.xPathBody).FirstOrDefault();
                if (body != null)
                    feed.Body = body.InnerHtml;

                var author = currentFeed.SelectNodes(resource.xPathAuthor).FirstOrDefault();
                if (author != null)
                    feed.Author = author.InnerHtml;

                var title = currentFeed.SelectNodes(resource.xPathTitle).FirstOrDefault();
                if (title != null)
                    feed.Author = title.InnerHtml;

                var date = currentFeed.SelectNodes(resource.xPathDate).FirstOrDefault();
                if (date != null)
                    feed.Author = date.InnerText;

                feed.Resources = resource;
                feeds.Add(feed);
            }

            resource.Feed = feeds;
        }
    }
}
