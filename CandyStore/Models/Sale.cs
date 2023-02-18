using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CandyStore.Models
{
    public class Sale
    {
        public int SaleID { get; set; }   
        public int ManagerID { get; set; }  
        public int ProductionID { get; set; }   
        public int BuyerID { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
                       ApplyFormatInEditMode = true)]
        [Display(Name = "Start Date")]
        public DateTime SaleDate { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public Manager Manager { get; set; }
        public Production Production { get; set; }
        public Buyer Buyer { get; set; }
    }
}
