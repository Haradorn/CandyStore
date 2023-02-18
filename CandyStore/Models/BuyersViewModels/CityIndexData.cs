using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyStore.Models.BuyersViewModels
{
    public class CityIndexData
    {
        public IEnumerable<City> Cities { get; set; }
        public IEnumerable<Buyer> Buyers { get; set; }
    }
}