using System.Collections.Generic;
using TheOldHat.Domain;

namespace TheOldHat.Models
{
    public class ProductViewModel
    {
        public IReadOnlyList<Product> Products { get; private set; }

        public ProductViewModel(IEnumerable<Product> products)
        {
            Products = new List<Product>(products);
        }
    }
}
