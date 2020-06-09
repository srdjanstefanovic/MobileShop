using MobileShop.Core.Contracts;
using MobileShop.Core.Models;
using MobileShop.Core.ViewModel;
using MobileShop.DataAccess.InMemory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileShop.WebUI.Controllers
{
    public class ProductManagerController : Controller
    {
        IRepository<Product> context;
        IRepository<Brand> brands;

        public ProductManagerController(IRepository<Product> productContext, IRepository<Brand> brandContext)
        {
            context = productContext;
            brands = brandContext;
        }

        // GET: ProductManager
        public ActionResult Index()
        {
            List<Product> products = context.Collection().ToList();
            return View(products);
        }

        public ActionResult Create()
        {
            ProductManagerViewModel viewModel = new ProductManagerViewModel();
            viewModel.Product = new Product();
            viewModel.Brands = brands.Collection();
            
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(Product product, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            else
            {
                if (file!=null)
                {
                    //rename the image, therefore it will have unique name in the app
                    product.Image = product.Id + Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath("//Content//ProductImages//") + product.Image);
                }

                context.Insert(product);
                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string id)
        {
            Product product = context.Find(id);
            if (product==null)
            {
                return HttpNotFound();
            }
            else
            {
                ProductManagerViewModel viewModel = new ProductManagerViewModel();
                viewModel.Product = product;
                viewModel.Brands = brands.Collection();
                return View(viewModel);
            }
        }

        [HttpPost]
        public ActionResult Edit(Product product, string id, HttpPostedFileBase file)
        {
            Product productToEdit = context.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(product);
                }

                if (file != null)
                {
                    //rename the image, therefore it will have unique name in the app
                    productToEdit.Image = product.Id + Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath("//Content//ProductImages//") + productToEdit.Image);
                }

                productToEdit.Name = product.Name;
                productToEdit.InternalMemory = product.InternalMemory;
                productToEdit.Brand = product.Brand;
                productToEdit.CameraMP = product.CameraMP;
                productToEdit.Price = product.Price;
                productToEdit.RAM = product.RAM;
                productToEdit.Description = product.Description;
                productToEdit.OS = product.OS;
                productToEdit.DisplaySize = product.DisplaySize;
                

                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete (string id)
        {
            Product productToDelete = context.Find(id);
            if (productToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(productToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelte(string id)
        {
            Product productToDelete = context.Find(id);
            if (productToDelete == null)
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