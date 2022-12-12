public class Stock
{
    public int sale_id {get;set;}
    public int employee_id { get; set; }
    public int product_id{get;set;}
    public double product_price{get;set;}
    public int sale_quantity{get;set;}
    public double sale_totalMoney{get;set;}
    public string? product_name{get;set;}
    public int machine_id{get;set;}
    public int refillorder_id { get; set; }
    public double order_totalPay { get; set; }
    public int order_quantity { get; set; }
    public int checkedBy_employee { get; set; }
    public bool order_status { get; set; }
     public int Qt{get;set;}
     public int Sqt{get;set;}
}