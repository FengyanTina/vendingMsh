public class Product
{
    public int product_id { get; set; }
    public string? product_name { get; set; }
    public double order_price { get; set; }
    public double sale_price { get; set; }
    public override string ToString()
    {
        return product_id + "\t\t " + product_name + "\t\t " + order_price + "\t\t\t " + sale_price ;
    }
}