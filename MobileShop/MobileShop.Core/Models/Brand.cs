using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileShop.Core.Models
{
    public class Brand : BaseEntity
    {
        
        [Required]
        public string BrandName { get; set; }

       
    }
}
