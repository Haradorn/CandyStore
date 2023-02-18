using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CandyStore.Models
{
    public class ProductType
    {
        public int ProductTypeID { get; set; }
        [StringLength(50)]
        public string ProductTypeName { get; set; }
        public ICollection<Production> Productions { get; set; }        
    }
}
