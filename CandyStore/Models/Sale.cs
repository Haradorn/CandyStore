using System.ComponentModel.DataAnnotations;

namespace CandyStore.Models
{
    public class Sale
    {
        public int SaleID { get; set; }   
        public int ManagerID { get; set; }  
        public int ProductionID { get; set; }   
        public int BuyerID { get; set; }    
        public DateTime SaleDate { get; set; }
        public decimal Price { get; set; }

        public Manager Manager { get; set; }
        public Production Production { get; set; }
    }
}
