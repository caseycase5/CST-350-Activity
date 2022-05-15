using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCoreFirstApp.Models {
    public class CarModel {
        [DisplayName("Id Number")]
        public int Id { get; set; }

        [DisplayName("Car Name")]
        public string Name { get; set; }

        [DisplayName("Cost to Customer")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; }

        [DisplayName("Car Build Date")]
        [DataType(DataType.Date)]
        public DateTime BuildDate { get; set; }

        public CarModel(int id, string name, decimal price, string description, DateTime buildDate) {
            Id = id;
            Name = name;
            Price = price;
            Description = description;
            BuildDate = buildDate;
        }
    }

}
