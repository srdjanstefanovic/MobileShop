using MobileShop.Core.Contracts;
using MobileShop.Core.Models;
using MobileShop.DataAccess.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileShop.WebUI.Controllers
{
    public class BrandManagerController : Controller
    {
        IRepository<Brand> context;

        public BrandManagerController(IRepository<Brand> context)
        {
            this.context = context;
        }

        // GET: BrandManager
        public ActionResult Index()
        {
            List<Brand> brands = context.Collection().ToList();
            return View(brands);
        }

        public ActionResult Create()
        {
            Brand brand = new Brand();
            return View(brand);
        }

        [HttpPost]
        public ActionResult Create(Brand brand)
        {
            if (!ModelState.IsValid)
            {
                return View(brand);
            }
            else
            {
                context.Insert(brand);
                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string id)
        {
            Brand brand = context.Find(id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(brand);
            }
        }

        [HttpPost]
        public ActionResult Edit(Brand brand, string id)
        {
            Brand brandToEdit = context.Find(id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(brand);
                }

                brandToEdit.BrandName = brand.BrandName;

                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(string id)
        {
            Brand brandToDelete = context.Find(id);
            if (brandToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(brandToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelte(string id)
        {
            Brand brandToDelete = context.Find(id);
            if (brandToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(id);
                context.Commit();
                return RedirectToAction("Index");
            }
        }
    }
}