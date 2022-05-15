using ASPCoreFirstApp.Models;
using ASPCoreFirstApp.Services;
using Bogus;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ASPCoreFirstApp.Controllers {
    public class ProductsController : Controller {
        // Comment out one to choose the repository source

        //HardCodedSampleDataRepository repository = new HardCodedSampleDataRepository();
        //ProductsDAO repository = new ProductsDAO();

        public IProductsDataService repository { get; set; }

        public ProductsController(IProductsDataService dataService) {
            repository = dataService;
        }

        // address is /products or /products/index
        public IActionResult Index() {
            return View(repository.AllProducts());
        }

        // Showing search results
        public IActionResult SearchResults(string searchTerm) {
            List<ProductModel> productList = repository.SearchProducts(searchTerm);
            return View("Index", productList);
        }

        // Showing a single product details
        public IActionResult ShowOneProduct(int Id) {
            return View(repository.GetProductById(Id));
        }

        public IActionResult ShowOneProductJSON(int Id) {
            return Json(repository.GetProductById(Id));
        }

        // Edit actions
        public IActionResult ShowEditForm(int Id) {
            return View(repository.GetProductById(Id));
        }

        public IActionResult ProcessEdit(ProductModel product) {
            repository.Update(product);
            return View("Index", repository.AllProducts());
        }

        public IActionResult ProcessEditReturnPartial(ProductModel product) {
            repository.Update(product);
            return PartialView("_productView", product);
        }

        // Delete actions

        public IActionResult DeleteProduct(ProductModel product) {
            repository.Delete(product);
            return View("Index", repository.AllProducts());
        }

        // Displays the search form
        public IActionResult SearchForm() {
            return View();
        }

        // address is /products/message
        public IActionResult Message() {
            return View();
        }

        // address is /products/welcome
        public IActionResult Welcome() {
            ViewBag.name = "User";
            ViewBag.secretNumber = 13;
            return View();
        }

    }
}
