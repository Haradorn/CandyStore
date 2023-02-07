using System.ComponentModel.DataAnnotations;

namespace CandyStore.Models
{
    public enum Category
    {
        First, Second
    }
    public class Manager
    {
        public int ManagerID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set;  }
        public DateTime DateBirth { get; set; }
        [DisplayFormat(NullDisplayText = "No category")]
        public Category? Category { get; set; }

        public ICollection<Sale> Sales { get; set; }
    }
}
