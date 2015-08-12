using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic.IServices;
using Model.Entities;

namespace DevPro.Controllers
{
    public class ResourceController : Controller
    {
        private IResourceService _resourceService;
        public ResourceController(IResourceService resourceService)
        {
            _resourceService = resourceService;
        }

        public ActionResult Index()
        {
            var resources = _resourceService.GetAllItems();
            return View(resources);
        }

        //
        // GET: /Resource/Details/5

        public ActionResult Details(int id)
        {
            var resource = _resourceService.GetById(id);
            if (resource.Feed == null)
            {
                resource.Feed = new Collection<Feed>();
            }
            return View(resource);
        }

        //
        // GET: /Resource/Create

        public ActionResult Create()
        {
            return View(new Resource());
        }

        //
        // POST: /Resource/Create

        [HttpPost]
        public ActionResult Create(Resource resource)
        {
            try
            {
                resource.LastUpdateDate = DateTime.Now;
               _resourceService.New(resource);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        //
        // GET: /Resource/Edit/5

        public ActionResult Edit(int id)
        {
           
            var resource = _resourceService.GetById(id);
          
            return View(resource);
        }

        //
        // POST: /Resource/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, Resource resource)
        {
            try
            {
                resource.LastUpdateDate = DateTime.Now;
               _resourceService.Update(resource);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(resource);
            }
        }

        //
        // GET: /Resource/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Resource/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
