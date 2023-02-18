using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CandyStore.Models
{
    public class City
    {
        public int CityID { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public ICollection<Buyer> Buyers { get; set; }  
    }
}
