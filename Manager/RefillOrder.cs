public class RefillOrder
{
    public int reillOrder_id { get; set; }
    public int employee_id { get; set; }
    public int machine_id { get; set; }
    public double order_totalPay { get; set; }
    public DateOnly order_date { get; set; }
    public int product_id { get; set; }
    public double product_price { get; set; }
    public string? product_name { get; set; }
    public int order_quantity { get; set; }
    

    public override string ToString()
    {
        return $@"";
    }
}