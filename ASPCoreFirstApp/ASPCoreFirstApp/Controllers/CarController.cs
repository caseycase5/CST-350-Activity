using ASPCoreFirstApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCoreFirstApp.Controllers {
    public class CarController : Controller {
        public IActionResult Index() {
            List<CarModel> carList = new List<CarModel>();

            // Creating Fake Data
            carList.Add(new CarModel(1, "Buick", 44999.99m, "A Buick Sedan.", System.DateTime.Now));
            carList.Add(new CarModel(2, "Ford", 34599.99m, "Ford SUV", System.DateTime.Now));
            carList.Add(new CarModel(3, "Aston Martin", 189999.99m, "A new Aston Martin Sedan", System.DateTime.Now));
            return View(carList);
        }
    }
}
