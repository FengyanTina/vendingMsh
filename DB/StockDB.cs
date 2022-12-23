using Dapper;
using MySqlConnector;
using System.Data;
public class StockDB
{
    private MySqlConnection connection;


    public StockDB()
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

    public List<Sales> StockByMachineId(int id)
    {
        Open();
        //Get all product including products not sold.
         
        var stocks = connection.Query<Sales>($@"WITH sold AS (SELECT saledetails.product_id, saledetails.sale_quantity, COALESCE(sum(saledetails.sale_quantity),0) AS Sqt 
            FROM saledetails
            JOIN sales
            ON sales.sale_id = saledetails.sale_id
            WHERE sales.machine_id = {id}  
            GROUP BY saledetails.product_id)
        SELECT  orderdetails.product_id,products.product_name,sum(orderdetails.order_quantity)AS Oqt,COALESCE(sold.Sqt,0)AS Sqt,
           (sum(orderdetails.order_quantity)-COALESCE(sold.Sqt,0)) AS Qt
        FROM orderdetails
        JOIN refillorders
        ON orderdetails.refillOrder_id = refillorders.refillOrder_id
        JOIN products ON orderdetails.product_id = products.product_id
        LEFT OUTER JOIN sold
        ON orderdetails.product_id  = sold.product_id
        WHERE refillorders.machine_id ={id} 
        GROUP BY orderdetails.product_id;").ToList();
         
        // var stocks = connection.Query<Sales>($@"WITH sold AS (SELECT saledetails.product_id, //saledetails.sale_quantity, sum(saledetails.sale_quantity) AS Sqt 
        //     FROM saledetails
        //     JOIN sales
        //     ON sales.sale_id = saledetails.sale_id
        //     WHERE sales.machine_id = {id}  
        //     GROUP BY saledetails.product_id)
        // SELECT  orderdetails.product_id,products.product_name,sum(orderdetails.order_quantity)AS Oqt,sold.Sqt,
        //     (sum(orderdetails.order_quantity)-sold.Sqt) AS Qt
        // FROM orderdetails
        // JOIN refillorders
        // ON orderdetails.refillOrder_id = refillorders.refillOrder_id
        // JOIN products ON orderdetails.product_id = products.product_id
        // LEFT OUTER JOIN sold
        // ON orderdetails.product_id  = sold.product_id
        // WHERE refillorders.machine_id ={id} AND sold.Sqt>0
        // GROUP BY orderdetails.product_id;").ToList();
        return stocks;
    }

     
}