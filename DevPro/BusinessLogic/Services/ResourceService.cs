using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

            WebClient wClient = new WebClient();

            

            var htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml(wClient.DownloadString(resource.Url));

            var feeds = new List<Feed>();

            HtmlAgilityPack.HtmlNode root = htmlDoc.DocumentNode;

            foreach (HtmlAgilityPack.HtmlNode currentFeed in root.SelectNodes((resource.xPathFeed)))
            {
                var feed = new Feed();

                var body = currentFeed.SelectSingleNode(resource.xPathBody);
                if (body != null)
                    feed.Body = body.InnerHtml;

                var author = currentFeed.SelectSingleNode(resource.xPathAuthor);
                if (author != null)
                    feed.Author = author.InnerHtml;

                var title = currentFeed.SelectSingleNode(resource.xPathTitle);
                if (title != null)
                    feed.Title = title.InnerHtml;

                var date = currentFeed.SelectSingleNode(resource.xPathDate);
                if (date != null)
                    feed.Date = new DateTime(date.GetAttributeValue("data-timestamp", 0));

                feed.Resources = resource;
                
                feeds.Add(feed);
            }

            resource.Feed = feeds;
        }
    }
}
