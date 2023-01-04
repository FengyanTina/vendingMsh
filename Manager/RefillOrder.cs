public class RefillOrder
{
    public int refillorder_id { get; set; }
    public int employee_id { get; set; }
    public int machine_id { get; set; }
    public double order_totalPay { get; set; }
    public DateTime order_date { get; set; }
    public int product_id { get; set; }
    public double product_price { get; set; }
    public string? product_name { get; set; }
    public int order_quantity { get; set; }
    public int checkedBy_employee { get; set; }
    public bool order_status { get; set; }
    

    public override string ToString()
    {
        return refillorder_id + "\t\t" + product_id + "\t\t" + product_name + "\t" + machine_id +"\t\t" + order_date.ToShortDateString() + "\t\t" + product_price + "\t\t" + order_quantity +  "\t\t" + order_totalPay + "\t\t\t" + employee_id + "\t\t\t" + order_status + "\t\t" + checkedBy_employee;
    }
}