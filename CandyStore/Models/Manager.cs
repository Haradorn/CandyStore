using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CandyStore.Models
{
    public enum Category
    {
        First, Second
    }
    public class Manager
    {
        public int ManagerID { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Имя не должно содержать более 50 символов.")]
        [Column("FirstName")]
        [Display(Name = "First Name")]
        public string FirstMidName { get; set;  }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Birth")]
        public DateTime DateBirth { get; set; }
        [DisplayFormat(NullDisplayText = "No category")]
        public Category? Category { get; set; }
        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return LastName + " " + FirstMidName;
            }
        }

        public ICollection<Sale> Sales { get; set; }
    }
}
