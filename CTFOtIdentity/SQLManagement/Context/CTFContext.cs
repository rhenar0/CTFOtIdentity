using CTFOt.SQLManagement.Definitions;
using Microsoft.EntityFrameworkCore;

namespace CTFOt.SQLManagement.Context;


public class CTFContext : DbContext
{
    public CTFContext(DbContextOptions<CTFContext> options) : base(options)
    {
    }
    
    public DbSet<CTFUsers> CTFUsers { get; set; }
    public DbSet<CTFTeams> CTFTeams { get; set; }
    public DbSet<CTFChalls> CTFChalls { get; set; }
    public DbSet<CTFCategories> CTFCategories { get; set; }
    public DbSet<CTFEtapes> CTFEtapes { get; set; }
    public DbSet<CTFGlobal> CTFGlobal { get; set; }
    public DbSet<CTFRessources> CTFRessources { get; set; }
    public DbSet<CTFScoring> CTFScoring { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CTFUsers>().HasData(GetCTFUsers());
        modelBuilder.Entity<CTFTeams>().HasData(GetCTFTeams());
        modelBuilder.Entity<CTFChalls>().HasData(GetCTFChalls());
        modelBuilder.Entity<CTFCategories>().HasData(GetCTFCategories());
        modelBuilder.Entity<CTFEtapes>().HasData(GetCTFEtapes());
        modelBuilder.Entity<CTFGlobal>().HasData(GetCTFGlobal());
        modelBuilder.Entity<CTFRessources>().HasData(GetCTFRessources());
        modelBuilder.Entity<CTFScoring>().HasData(GetCTFScoring());
        base.OnModelCreating(modelBuilder);
    }

    private List<CTFScoring> GetCTFScoring()
    {
        return new List<CTFScoring>
        {
            new CTFScoring
            {
                Id = 1, IdTeam = 1, IdEtape = 1, IdPlayer = 1, Points = 0, DateTime = "2023-05-05 10:00:00"
            },
            new CTFScoring
            {
                Id = 2, IdTeam = 2, IdEtape = 1, IdPlayer = 2, Points = 0, DateTime = "2023-05-05 10:00:00"
            },
        };
    }
    
    private List<CTFRessources> GetCTFRessources()
    {
        return new List<CTFRessources>
        {
            new CTFRessources
            {
                Id = 1, Name = "hello.txt", Link = "https://boubouh.fr/", Type = "FILES", IdAssociatedEta = 1
            },
            new CTFRessources
            {
                Id = 2, Name = "Herobrine.FR", Link = "https://www.herobrine.fr/", Type = "LINK", IdAssociatedEta = 1
            },
            new CTFRessources
            {
                Id = 3, Name = "hello.txt", Link = "https://boubouh.fr/", Type = "FILES", IdAssociatedEta = 2
            }
        };
    }
    
    private List<CTFUsers> GetCTFUsers()
    {
        return new List<CTFUsers>
        {
            new CTFUsers
            {
                Id = 1, Pseudo = "Rhenar", Score = 0, AssignedChalls = "{}", ChkPassword = "a7e4ec9e259246db346ac88b10f32901", TeamId = 1
            },
            new CTFUsers
            {
                Id = 2, Pseudo = "Segrard", Score = 100, AssignedChalls = "{1}", ChkPassword = "a7e4ec9e259246db346ac88b10f32901", TeamId = 2
            }
        };
    }
    
    private List<CTFTeams> GetCTFTeams()
    {
        return new List<CTFTeams>
        {
            new CTFTeams
            {
                Id = 1, Name = "TeamTest", Score = 0, Members = "{1}", ChkPassword = "a7e4ec9e259246db346ac88b10f32901", ChallsSucceed = "[{\"etaId\": [0]}]"
            },
            new CTFTeams
            {
                Id = 2, Name = "Toutout", Score = 100, Members = "{2}", ChkPassword = "a7e4ec9e259246db346ac88b10f32901", ChallsSucceed = "[{\"etaId\": [0]}]"
            }
        };
    }
    
    private List<CTFChalls> GetCTFChalls()
    {
        return new List<CTFChalls>
        {
            new CTFChalls
            {
                Id = 1, Name = "ChallTest", Actif = true, IDCategories = 1, Image = "https://cdn-icons-png.flaticon.com/512/223/223203.png"
            },
            new CTFChalls
            {
                Id = 2, Name = "ChallTest2", Actif = true, IDCategories = 2, Image = "https://cdn-icons-png.flaticon.com/512/223/223203.png"
            },
            new CTFChalls
            {
                Id = 3, Name = "ChallTest3", Actif = false, IDCategories = 1, Image = "https://cdn-icons-png.flaticon.com/512/223/223203.png"
            }
        };
    }
    
    private List<CTFCategories> GetCTFCategories()
    {
        return new List<CTFCategories>
        {
            new CTFCategories
            {
                Id = 1, Name = "CatTest"
            },
            new CTFCategories
            {
                Id = 2, Name = "CatTest2"
            }
        };
    }
    
    private List<CTFEtapes> GetCTFEtapes()
    {
        return new List<CTFEtapes>
        {
            new CTFEtapes
            {
                Id = 1, Name = "EtapeTest", Actif = true, Description = "Test", Flag = "OTH{Test}", Img = "https://cdn-icons-png.flaticon.com/512/223/223203.png", LinkedChalls = 1, Order = 1, Points = 100, Categorie = "CatTest"
            },
            new CTFEtapes
            {
                Id = 2, Name = "EtapeTe", Actif = true, Description = "Test", Flag = "OTH{Test}", Img = "https://cdn-icons-png.flaticon.com/512/223/223203.png", LinkedChalls = 1, Order = 2, Points = 100, Categorie = "CatTest"
            },
            new CTFEtapes
            {
                Id = 3, Name = "Etapest", Actif = true, Description = "Test", Flag = "OTH{Test}", Img = "https://cdn-icons-png.flaticon.com/512/223/223203.png", LinkedChalls = 2, Order = 1, Points = 100, Categorie = "CatTest2"
            },
            new CTFEtapes
            {
                Id = 4, Name = "ETTE", Actif = false, Description = "Test", Flag = "OTH{Test}", Img = "https://cdn-icons-png.flaticon.com/512/223/223203.png", LinkedChalls = 2, Order = 2, Points = 100, Categorie = "CatTest2"
            }
        };
    }
    
    private List<CTFGlobal> GetCTFGlobal()
    {
        return new List<CTFGlobal>
        {
            new CTFGlobal
            {
                Id = 1, Dend = "2021-01-01 00:00:00", Dstart = "2021-01-01 00:00:00" 
            }
        };
    }

}