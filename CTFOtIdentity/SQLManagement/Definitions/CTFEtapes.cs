namespace CTFOt.SQLManagement.Definitions;

public class CTFEtapes
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Flag { get; set; }
    public string Description { get; set; }
    public string Img { get; set; }
    public int Points { get; set; }
    public int Order { get; set; }
    public int LinkedChalls { get; set; }
    public bool Actif { get; set; }
    public string Categorie { get; set; }
}