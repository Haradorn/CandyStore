using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CandyStore.Models
{
    public class Buyer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Number")]
        public int BuyerID { get; set; }
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }
        [StringLength(150)]
        public string Adress { get; set;}
        public int? CityID { get; set; }
        public City? City { get; set; }
        public ICollection<Sale> Sales { get; set; }
    }
}
