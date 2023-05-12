namespace CTFOtIdentity.SQLManagement.Definitions;

public class CTFUsers
{
    public int Id { get; set; }
    public string Pseudo { get; set; }
    public string Mail { get; set; }
    public string ChkPassword { get; set; }
    public long Score { get; set; }
    public string AssignedChalls { get; set; }
    public int TeamId { get; set; }
}