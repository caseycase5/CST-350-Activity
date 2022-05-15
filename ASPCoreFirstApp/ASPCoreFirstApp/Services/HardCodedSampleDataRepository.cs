using ASPCoreFirstApp.Models;
using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCoreFirstApp.Services {
    public class HardCodedSampleDataRepository : IProductsDataService {
        // Product List
        static List<ProductModel> productList;
        
        public HardCodedSampleDataRepository() {
            List<ProductModel> productList = new List<ProductModel>();

            // Creating Fake Data
            productList.Add(new ProductModel(1, "Keyboard", 59.99m, "A new keyboard to type on."));
            productList.Add(new ProductModel(2, "Water Bottle", 10.99m, "Something to drink out of."));
            productList.Add(new ProductModel(3, "Desk Chair", 189.99m, "A comfy seat to sit on."));

            for (int i = 0; i < 100; i++) {
                productList.Add(new Faker<ProductModel>()
                    .RuleFor(p => p.Id, i + 4)
                    .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                    .RuleFor(p => p.Price, f => f.Random.Decimal(100))
                    .RuleFor(p => p.Description, f => f.Commerce.ProductDescription())
                    );
            }
        }

        public List<ProductModel> AllProducts() {
            return productList;
        }

        public int Delete(ProductModel product) {
            throw new NotImplementedException();
        }

        public ProductModel GetProductById(int id) {
            throw new NotImplementedException();
        }

        public int Insert(ProductModel product) {
            throw new NotImplementedException();
        }

        public List<ProductModel> SearchProducts(string searchTerm) {
            throw new NotImplementedException();
        }

        public int Update(ProductModel product) {
            throw new NotImplementedException();
        }
    }
}
