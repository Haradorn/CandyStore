using System.ComponentModel.DataAnnotations.Schema;

namespace CandyStore.Models
{
    public class Production
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductionID { get; set; }   
        public int ProductTypeID { get; set; }  
        public string Name { get; set; }

        public ICollection<Sale> Sales { get; set; }
    }
}
