using ASPCoreFirstApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCoreFirstApp.Services {
    public class ProductsDAO : IProductsDataService {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public List<ProductModel> AllProducts() {
            // Assume nothing is found
            List<ProductModel> foundProducts = new List<ProductModel>();

            // SQL prepared statement
            string sqlStatement = "SELECT * FROM dbo.Products";

            // Attempting to connect
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                try {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while(reader.Read()) {
                        foundProducts.Add(new ProductModel((int)reader[0], (string)reader[1], (decimal)reader[2], (string)reader[3]));
                    }
                }
                catch(Exception e) {
                    Console.WriteLine(e.Message);
                }
            }

            return foundProducts;
        }

        public int Delete(ProductModel product) {
            // Returns -1 if update fails
            int newIdNumber = -1;

            using (SqlConnection connection = new SqlConnection(connectionString)) {
                string query = "DELETE FROM dbo.Products WHERE Id = @Id";

                // Define the value of the placeholder in the SQL query
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Id", product.Id);

                try {
                    connection.Open();
                    newIdNumber = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception e) {
                    Console.WriteLine(e.Message);
                }
            }

            return newIdNumber;
        }

        public ProductModel GetProductById(int id) {
            ProductModel foundProduct = null;

            // Prepared SQL statement
            string sqlStatement = "SELECT * FROM dbo.Products WHERE Id = @id";

            using (SqlConnection connection = new SqlConnection(connectionString)) {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                // Assigning a parameter to the placeholder
                command.Parameters.AddWithValue("@id", id);

                try {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    
                    while (reader.Read()) {
                        foundProduct = new ProductModel((int)reader[0], (string)reader[1], (decimal)reader[2], (string)reader[3]);
                    }
                }
                catch(Exception e) {
                    Console.WriteLine(e.Message);
                }
            }

            return foundProduct;
        }

        public int Insert(ProductModel product) {
            throw new NotImplementedException();
        }

        public List<ProductModel> SearchProducts(string searchTerm) {
            List<ProductModel> foundProducts = new List<ProductModel>();

            // Prepared SQL statement
            string sqlStatement = "SELECT * FROM dbo.Products WHERE Name LIKE @Name";

            using(SqlConnection connection = new SqlConnection(connectionString)) {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                // Define the value of the placeholder in the SQL query
                command.Parameters.AddWithValue("@Name", '%' + searchTerm + '%');

                try {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while(reader.Read()) {
                        foundProducts.Add(new ProductModel((int)reader[0], (string)reader[1], (decimal)reader[2], (string)reader[3]));
                    }
                }
                catch(Exception e) {
                    Console.WriteLine(e.Message);
                }
            }

            return foundProducts;
        }

        public int Update(ProductModel product) {
            // Returns -1 if update fails
            int newIdNumber = -1;

            using (SqlConnection connection = new SqlConnection(connectionString)) {
                string query = "UPDATE dbo.Products SET Name = @Name, Price = @Price, Description = @Description WHERE Id = @Id";

                // Define the value of the placeholder in the SQL query
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Id", product.Id);
                command.Parameters.AddWithValue("@Name", product.Name);
                command.Parameters.AddWithValue("@Price", product.Price);
                command.Parameters.AddWithValue("@Description", product.Description);

                try {
                    connection.Open();
                    newIdNumber = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception e) {
                    Console.WriteLine(e.Message);
                }
            }

            return newIdNumber;
        }
    }
}
