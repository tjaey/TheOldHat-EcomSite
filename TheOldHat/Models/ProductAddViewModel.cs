using System.ComponentModel.DataAnnotations;
using TheOldHat.Domain;

namespace TheOldHat.Models
{
    public class ProductAddViewModel
    {
        [Display(Name = "Id")]
        [Required(ErrorMessage = "Product ID is missing")]
        public int Id { get; set; }

        [Display(Name = "Name")]
        [StringLength(50)]
        [Required(ErrorMessage = "Please enter a product name")]
        public string Name { get; set; }

        [Display(Name = "Count")]
        public int Count { get; set; }

        [Display(Name = "Description")]
        [StringLength(200)]
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
