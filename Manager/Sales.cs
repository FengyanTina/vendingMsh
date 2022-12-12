public class Sales
{
    public int sale_id {get;set;}
    public int machine_id {get;set;}
    public DateTime sale_date{get;set;}
    public int product_id{get;set;}
    public double product_price{get;set;}
    public int sale_quantity{get;set;}
    public double sale_totalMoney{get;set;}
    public string? product_name{get;set;}
    public int refillorder_id { get; set; }
    public int employee_id { get; set; }
    public double order_totalPay { get; set; }
    public DateTime order_date { get; set; }
    public int order_quantity { get; set; }
    public int checkedBy_employee { get; set; }
    public bool order_status { get; set; }
    public int Qt{get;set;}
    public int Sqt{get;set;}
    public int Oqt{get;set;}
    


    // public override string ToString()
    // {
    //     return sale_id + "\t\t" + product_id + "\t\t" + product_name + "\t" + machine_id +"\t\t" + sale_date.ToShortDateString() + "\t\t" + product_price + "\t\t" + sale_quantity +  "\t\t" + sale_totalMoney;
    // }
}