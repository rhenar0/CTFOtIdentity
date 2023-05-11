namespace CTFOt.SQLManagement.Definitions;

public class CTFScoring
{
    public int Id { get; set; }
    public int IdTeam { get; set; }
    public int IdEtape { get; set; }
    public int IdPlayer { get; set; }
    public int Points { get; set; }
    public string DateTime { get; set; }
}