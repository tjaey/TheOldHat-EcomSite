using System.Collections.Generic;
using TheOldHat.Domain;

namespace TheOldHat.Models
{
    public class ProductUpdateViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public string Description { get; set; }

        public ProductUpdateViewModel()
        {
        }

        public ProductUpdateViewModel(Product product)
        {
            CopyInformation(product);
        }

        private void CopyInformation(Product product)
        {
            Id = product.Id;
            Name = product.Name;
            Count = Count;
            Description = product.Description;
        }
    }
}
