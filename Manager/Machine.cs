public class Machine
{
    public int machine_id{get;set;}
    public string? machine_location{get;set;}
    public string? machine_model{get;set;}

    public override string ToString()
    {
        return "\t" + machine_id + "\t" +  machine_location + "\t\t " + machine_model;
    }
}