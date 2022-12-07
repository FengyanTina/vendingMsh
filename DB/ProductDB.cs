using Dapper;
using MySqlConnector;
using System.Data;
public class ProductDB
{
    private MySqlConnection connection;

    public ProductDB()
    {
      connection = new MySqlConnection(("Server=localhost;Database=vendingmachine;Uid=Tina;Pwd=123456;"));
    }

    public void Connect()
    {
        
    }
    public void Open()
    {
        try
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();
        }
        catch (Exception e)
        {

            throw new FieldAccessException("DB is not accessable", e);
        }
    }

    public List<Product> GetProducts() //tested
    {
        Open();
        var products = connection.Query<Product>("SELECT product_id, product_name FROM products;").ToList();
        return products;
    }

    public Product SearchProductByName(string name)//tested
    {
        Open();
        var product = connection.QuerySingle<Product>(@$"SELECT * FROM `products` WHERE product_name = '{name}';");
        return product;
    }

    public int InsertProduct(string name) //tested
    {
         Open();
        string sql = @$"INSERT INTO products (product_name) VALUES ('{name}');SELECT LAST_INSERT_ID();";
        int id = connection.QuerySingle<int>(sql);
        return id;
    }

    public void DeleteProductById(int id)//tested
    {
         Open();
        var deletedproduct = connection.Query<Product>(@$"DELETE FROM `products` WHERE product_id = {id};");
    }

    public void UpdateProductById(int id,string newname) //tested
    {
         Open();
        var updateproduct = connection.Query<Product>(@$"UPDATE `products` SET product_name = '{newname}'WHERE product_id = {id};");
    }
}