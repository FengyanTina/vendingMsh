using Dapper;
using MySqlConnector;
using System.Data;
public class SaleDB 
{
    
    private MySqlConnection connection;


    public SaleDB()
    {
        connection = new MySqlConnection(("Server=localhost;Database=vendingmachine;Uid=Tina;Pwd=123456;"));

    }
      public void Open()
    {
        try
        {
           if(connection.State != ConnectionState.Open)
            connection.Open(); 
        }
        catch (Exception e)
        {
            
            throw new FieldAccessException("DB is not accessable",e);
        }
    }

    public List<Sales> AllProductTotalSalesList()
    {
        Open();

         var sales = connection.Query<Sales>($@"SELECT products.product_id,products.product_name,products.sale_price,COALESCE(sum(saledetails.sale_quantity),0) AS sale_quantity,COALESCE(saledetails.product_price*sum(saledetails.sale_quantity),0) AS sale_totalMoney
        FROM ((products 
        LEFT JOIN saledetails ON products.product_id = saledetails.product_id)
        LEFT JOIN sales ON sales.sale_id = saledetails.sale_id)
        GROUP BY products.product_id;").ToList();
        // var sales = connection.Query<Sales>($@"SELECT products.product_id,products.product_name,saledetails.product_price,sum(saledetails.sale_quantity) AS sale_quantity,(saledetails.product_price*sum(saledetails.sale_quantity)) AS sale_totalMoney
        // FROM ((products 
        // LEFT JOIN saledetails ON products.product_id = saledetails.product_id)
        // LEFT JOIN sales ON sales.sale_id = saledetails.sale_id)
        // GROUP BY products.product_id;").ToList();
        return sales;
    }

    public List<Sales> SalePerformenceByMachineId(int id)
    {
        Open();
        //Get all product including products not sold.
         var sales = connection.Query<Sales>($@"WITH st AS (SELECT sd.product_id,sd.product_price,sum(sd.sale_quantity) AS sale_quantity,(sd.product_price*sale_quantity) AS sale_totalMoney
        FROM saledetails sd
        INNER JOIN sales s ON s.sale_id = sd.sale_id
        WHERE s.machine_id = {id}
        GROUP BY sd.product_id )
        SELECT  p.product_id ,p.product_name,COALESCE(st.product_price,0) AS product_price, COALESCE(st.sale_quantity,0) AS sale_quantity,COALESCE(st.sale_totalMoney,0) AS sale_totalMoney
        FROM products p
        LEFT JOIN saledetails sd
        ON sd.product_id = p.product_id
        LEFT OUTER JOIN st
        ON sd.product_id  = st.product_id
        GROUP BY p.product_id;").ToList();
        // var sales = connection.Query<Sales>($@"SELECT saledetails.product_id,products.product_name,saledetails.product_price,sum(saledetails.sale_quantity) AS sale_quantity,(saledetails.product_price*sum(saledetails.sale_quantity)) AS sale_totalMoney
        // FROM ((saledetails
        // INNER JOIN sales ON saledetails.sale_id = sales.sale_id)
        // INNER JOIN products ON products.product_id = saledetails.product_id)
        // WHERE sales.machine_id ={id}
        // GROUP BY saledetails.product_id;").ToList();
        return sales;
    }

    public List<Sales> SalePerformenceByProductId(int id)
    {
        Open();
        //Get all product including products not sold.
         var sales = connection.Query<Sales>($@"SELECT products.product_id,products.product_name,saledetails.product_price,sum(saledetails.sale_quantity) AS sale_quantity,(saledetails.product_price*sum(saledetails.sale_quantity)) AS sale_totalMoney,sales.machine_id
         FROM ((products 
         LEFT JOIN saledetails ON products.product_id = saledetails.product_id)
         LEFT JOIN sales ON sales.sale_id = saledetails.sale_id)
         WHERE saledetails.product_id = {id}
         GROUP BY products.product_id,sales.machine_id;").ToList();
        
        return sales;
    }

    public List<Sales> SaleListBySalesId(int id)
    {
        Open();
        //Get all product including products not sold.
         var sales = connection.Query<Sales>($@"SELECT p.product_id,p.product_name,sd.product_price,sum(sd.sale_quantity) AS sale_quantity,(sd.product_price*sum(sd.sale_quantity)) AS sale_totalMoney,s.machine_id,s.sale_date
         FROM ((products p
         INNER JOIN saledetails sd ON p.product_id = sd.product_id)
         INNER JOIN sales s ON s.sale_id = sd.sale_id)
         WHERE sd.sale_id = {id}
         GROUP BY sd.product_id;").ToList();
        
        return sales;
    }

    public int InsertSales(int machineID, DateTime date)
    {
        Open();
        var r = new DynamicParameters();
        r.Add("@machine_id", machineID);
        r.Add("@sale_date", date);
        
        string sql = $@"INSERT INTO Sales (machine_id,  sale_date) VALUES (@machine_id,@sale_date); SELECT LAST_INSERT_ID() ";
        int Id = connection.Query<int>(sql, r).First();
        return Id;
    }

    public int InsertSaleDetails (int salesID, int productID, double productPrice,int quantity)//tested
    {
        Open();
        var r = new DynamicParameters();
        r.Add("@sale_id", salesID);
        r.Add("@product_id", productID);
        r.Add("@product_price", productPrice);
        r.Add("@sale_quantity", quantity);
        string sql = $@"INSERT INTO saledetails (sale_id, product_id, product_price,sale_quantity) VALUES (@sale_id,@product_id,@product_price,@sale_quantity); SELECT LAST_INSERT_ID() ";
        int Id = connection.Query<int>(sql, r).First();
        return Id;
    }


    
    

}
