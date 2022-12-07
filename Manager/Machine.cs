public class Mashine
{
    public int machine_id{get;set;}
    public string? machine_location{get;set;}
    public string? machine_model{get;set;}

    public override string ToString()
    {
        return @$"Machine ID" + " " + machine_id + "\nMachine Location" + " " + machine_location + "\nMachine Model" + " " + machine_model;
    }
}