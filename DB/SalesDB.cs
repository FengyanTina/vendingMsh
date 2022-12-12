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
        var sales = connection.Query<Sales>($@"SELECT products.product_id,products.product_name,saledetails.product_price,sum(saledetails.sale_quantity) AS sale_quantity,(saledetails.product_price*sum(saledetails.sale_quantity)) AS sale_totalMoney
        FROM ((products 
        LEFT JOIN saledetails ON products.product_id = saledetails.product_id)
        LEFT JOIN sales ON sales.sale_id = saledetails.sale_id)
        GROUP BY products.product_id;").ToList();
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
        SELECT  p.product_id ,p.product_name,st.product_price, st.sale_quantity,st.sale_totalMoney
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
        // GROUP BY saledetails.product_id
        // ORDER BY sale_quantity;").ToList();
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

    public int InsertRefillOrder(int machineID, int employeeID, DateTime date,bool status,int id)//tested
    {
        Open();
        var r = new DynamicParameters();
        r.Add("@machine_id", machineID);
        r.Add("@employee_id", employeeID);
        r.Add("@order_date", date);
         r.Add("@order_status", status);
         r.Add("@checkedBy_employee", id);
        string sql = $@"INSERT INTO refillorders (machine_id, employee_id, order_date,order_status,checkedBy_employee) VALUES (@machine_id,@employee_id,@order_date,@order_status,@checkedBy_employee); SELECT LAST_INSERT_ID() ";
        int Id = connection.Query<int>(sql, r).First();
        return Id;
    }

    public int InsertOrderDetails (int refillOrderID, int productID, double productPrice,int quantity)//tested
    {
        Open();
        var r = new DynamicParameters();
        r.Add("@refillorder_id", refillOrderID);
        r.Add("@product_id", productID);
        r.Add("@product_price", productPrice);
        r.Add("@order_quantity", quantity);
        string sql = $@"INSERT INTO orderdetails (refillorder_id, product_id, product_price,order_quantity) VALUES (@refillorder_id,@product_id,@product_price,@order_quantity); SELECT LAST_INSERT_ID() ";
        int Id = connection.Query<int>(sql, r).First();
        return Id;
    }


    
    

}
