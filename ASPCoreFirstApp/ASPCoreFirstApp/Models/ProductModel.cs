using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCoreFirstApp.Models {
    public class ProductModel {
        [DisplayName("Id Number")]
        public int Id { get; set; }

        [DisplayName("Product Name")]
        public string Name { get; set; }

        [DisplayName("Cost to Customer")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; }

        public ProductModel(int id, string name, decimal price, string description) {
            Id = id;
            Name = name;
            Price = price;
            Description = description;
        }

        public ProductModel() {

        }
    }
}
