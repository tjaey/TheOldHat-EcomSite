using System;
using System.Collections.Generic;
using System.Linq;
using TheOldHat.Domain;
using TheOldHat.Common.Interfaces;

namespace TheOldHat.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {

        private static readonly List<Product> _allProducts = new List<Product>();

        public ProductRepository()
        {
            Init();
        }

        public IEnumerable<Product> GetAll()
        {
            return _allProducts;
        }

        public IEnumerable<Product> GetAllMatching(Predicate<Product> condition)
        {
            return _allProducts.Where(u => condition(u)).ToArray();
        }

        public Product GetOne(int id)
        {
            return _allProducts.FirstOrDefault(u => u.Id == id);
        }

        public void Add(Product item)
        {
            _allProducts.Add(item);
        }

        public void Update(Product item)
        {
            var product = GetOne(item.Id);
            if(product == null)
            {
                throw new ArgumentException("Product not found");
            }

            product.ChangeName(item.Name);
            product.ChangeCount(item.Count);
            product.ChangeDescription(item.Description);
        }

        public void Delete(int id)
        {
            var product = GetOne(id);

            if(product == null)
            {
                throw new ArgumentException("Product not found");
            }

            _allProducts.Remove(product);
        }

        private void Init()
        {
            if(_allProducts.Any())
            {
                return;
            }

            var products = new List<Product>()
            {
                new Product(0, "doll", 4, "a doll"),
                new Product(1, "bear", 1, "a bear")               
            };

            _allProducts.AddRange(products);

        }
    }
}
