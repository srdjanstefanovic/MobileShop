using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MobileShop.Core.Models
{
    public class Product : BaseEntity
    {
      
        [StringLength(30)]
        [Required]
        public string Name { get; set; }
        [Required]
        public string Brand { get; set; }
        public OS OS { get; set; }
        [Range(0.128,16)]
        public int RAM { get; set; }
        [Range(1,1000)]
        [DisplayName("Internal memory (GB)")]
        public int InternalMemory { get; set; }
        [Range(1, 128)]
        public int CameraMP { get; set; }
        [Range(1, 10)]
        public double DisplaySize { get; set; }
        [Required]
        public string Description { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }

        

    }
}
