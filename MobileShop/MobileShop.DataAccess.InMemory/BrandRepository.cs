using MobileShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace MobileShop.DataAccess.InMemory
{
    public class BrandRepository 
    {
        ObjectCache cache = MemoryCache.Default;
        List<Brand> brands;

        public BrandRepository()
        {
            brands = cache["brands"] as List<Brand>;
            if (brands == null)
            {
                brands = new List<Brand>();
            }
        }

        public void Commit()
        {
            cache["brands"] = brands;
        }

        public void Insert(Brand brand)
        {
            brands.Add(brand);
        }

        public void Update(Brand brand)
        {
            Brand brandToUpdate = brands.Find(p => p.Id == brand.Id);
            if (brandToUpdate != null)
            {
                brandToUpdate = brand;
            }
            else
            {
                throw new Exception("Brand not found!");
            }
        }

        public Brand Find(string id)
        {
            Brand brand = brands.Find(p => p.Id == id);
            if (brand != null)
            {
                return brand;
            }
            else
            {
                throw new Exception("Brand not found!");
            }
        }

        public IQueryable<Brand> Collection()
        {
            return brands.AsQueryable();
        }

        public void Delete(string id)
        {
            Brand brandToDelete = brands.Find(p => p.Id == id);
            if (brandToDelete != null)
            {
                brands.Remove(brandToDelete);
            }
            else
            {
                throw new Exception("Brand not found!");
            }
        }
    }
}
