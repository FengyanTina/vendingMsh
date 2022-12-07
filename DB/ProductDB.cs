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

    public List<Product> GetProducts()
    {
        Open();
        var products = connection.Query<Product>("SELECT product_id, product_name FROM products;").ToList();
        return products;
    }

    public Product SearchProductByName(string name)
    {
        Open();
        var product = connection.QuerySingle<Product>(@$"SELECT * FROM `products` WHERE product_name = '{name}';");
        return product;
    }
}