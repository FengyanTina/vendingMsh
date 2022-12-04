public class Product
{
    public int product_id { get; set; }
    public string product_name { get; set; }
    
    public override string ToString()
    {
        return $"ProductID: " +  "Product Name" + "\n" + product_id + " " + product_name ;
    }
}