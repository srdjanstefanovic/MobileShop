using MobileShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileShop.Core.ViewModel
{
    public class ProductManagerViewModel
    {
        public Product Product { get; set; }
        public IEnumerable<Brand> Brands { get; set; }
        public IEnumerable<OS> OS { get; set; }
    }
}
