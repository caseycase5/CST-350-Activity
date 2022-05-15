using ASPCoreFirstApp.Models;
using ASPCoreFirstApp.Services;
using Bogus;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Description;

namespace ASPCoreFirstApp.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsAPIController : ControllerBase {

        ProductsDAO repository = new ProductsDAO();

        public ProductsAPIController() {
            repository = new ProductsDAO();
        }

        // address is /api/productsapi
        [HttpGet]
        [ResponseType(typeof(List <ProductDTO>))]
        public IEnumerable<ProductDTO> Index() {
            // Get all products
            List<ProductModel> productList = repository.AllProducts();
            // Translate to DTO
            IEnumerable<ProductDTO> productDTOList = from p in productList
                                                     select
                                                     new ProductDTO(p.Id, p.Name, p.Price, p.Description);
            return productDTOList;
        }


        // Showing search results
        // Address: /api/productsapi/searchresults/xyhz
        [HttpGet("searchresults/{searchTerm}")]
        public IEnumerable<ProductDTO> SearchResults(string searchTerm) {
            List<ProductModel> productList = repository.SearchProducts(searchTerm);
            // Translate to DTO
            List<ProductDTO> productDTOList = new List<ProductDTO>();
            foreach (ProductModel p in productList) {
                productDTOList.Add(new ProductDTO(p.Id, p.Name, p.Price, p.Description));
            }
            return productDTOList;
        }

        // Showing a single product details
        // Address: /api/productsapi/showoneproduct/3
        [HttpGet("showoneproduct/{Id}")]
        [ResponseType(typeof(ProductDTO))]
        public ActionResult<ProductDTO> ShowOneProduct(int Id) {
            ProductModel product = repository.GetProductById(Id);

            //Create a new DTO based on this product
            ProductDTO productDTO = new ProductDTO(product.Id, product.Name, product.Price, product.Description);

            // return the DTO
            return productDTO;
        }

        // Address: /api/productsapi/processedit/product
        [HttpPut("processedit")]
        [ResponseType(typeof(List<ProductDTO>))]
        public IEnumerable<ProductDTO> ProcessEdit(ProductModel product) {
            repository.Update(product);
            List<ProductModel> productList = repository.AllProducts();
            // Translate to DTO
            List<ProductDTO> productDTOList = new List<ProductDTO>();
            foreach (ProductModel p in productList) {
                productDTOList.Add(new ProductDTO(p.Id, p.Name, p.Price, p.Description));
            }
            return productDTOList;
        }

        // Address: /api/productsapi/processeditreturnpartial/product
        [HttpPut("ProcessEditReturnPartial")]
        [ResponseType(typeof(ProductDTO))]
        public ActionResult <ProductDTO> ProcessEditReturnPartial(ProductModel product) {
            repository.Update(product);
            ProductModel updatedProduct = repository.GetProductById(product.Id);
            ProductDTO productDTO = new ProductDTO(product.Id, product.Name, product.Price, product.Description);
            return productDTO;
        }

    }
}
