using System;
using TheOldHat.Domain;

namespace TheOldHat.Models
{
    public class ProductAddViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public string Description { get; set; }

        public ProductAddViewModel()
        {
        }

        public ProductAddViewModel(Product product)
        {
            CopyInformation(product);
        }

        private void CopyInformation(Product product)
        {
            Id = product.Id;
            Name = product.Name;
            Count = product.Count;
            Description = product.Description;
        }

    }
}
