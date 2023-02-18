using System;
using System.ComponentModel.DataAnnotations;
using CandyStore.Models;

namespace CandyStore.Pages.Managers.CandyViewModels
{
    public class CategoryDateGroup
    {
        public Category? CategoryName { get; set; }

        public int ManagerCount { get; set; }
    }
}
