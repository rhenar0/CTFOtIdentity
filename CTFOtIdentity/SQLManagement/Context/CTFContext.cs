using CTFOtIdentity.SQLManagement.Definitions;
using Microsoft.EntityFrameworkCore;

namespace CTFOtIdentity.SQLManagement.Context;


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
                Id = 1, IdTeam = 1, IdEtape = 999, IdPlayer = 1, Points = 0, DateTime = "2023-06-14 15:30:00"
            },
            new CTFScoring
            {
                Id = 2, IdTeam = 2, IdEtape = 999, IdPlayer = 8, Points = 0, DateTime = "2023-06-14 15:30:00"
            },
            new CTFScoring
            {
                Id = 3, IdTeam = 3, IdEtape = 999, IdPlayer = 16, Points = 0, DateTime = "2023-06-14 15:30:00"
            }
        };
    }
    
    private List<CTFRessources> GetCTFRessources()
    {
        return new List<CTFRessources>
        {
            new CTFRessources
            {
                Id = 1, Name = "weird_file.wav", Link = "https://cdn.discordapp.com/attachments/850005023218991105/1115609930272088095/weird_file.wav", Type = "FILES", IdAssociatedEta = 3
            },
            new CTFRessources
            {
                Id = 2, Name = "image1.png", Link = "https://media.discordapp.net/attachments/850005023218991105/1115610729173762208/image1.png?width=1220&height=1166", Type = "FILES", IdAssociatedEta = 4
            },
            new CTFRessources
            {
                Id = 3, Name = "image2.png", Link = "https://media.discordapp.net/attachments/850005023218991105/1115610728397799474/image2.png?width=1062&height=1166", Type = "FILES", IdAssociatedEta = 4
            },
            new CTFRessources
            {
                Id = 4, Name = "Site Web", Link = "http://192.168.208.17/", Type = "LINK", IdAssociatedEta = 7
            },
            new CTFRessources
            {
                Id = 5, Name = "Site Web", Link = "http://192.168.208.18/", Type = "LINK", IdAssociatedEta = 8
            },
            new CTFRessources
            {
                Id = 6, Name = "Site Web", Link = "http://192.168.208.18/", Type = "LINK", IdAssociatedEta = 9
            },
            new CTFRessources
            {
                Id = 7, Name = "6602", Link = "http://192.168.208.16/img.png", Type = "FILES", IdAssociatedEta = 10
            }
        };
    }
    
    private List<CTFUsers> GetCTFUsers()
    {
        return new List<CTFUsers>
        {
            new CTFUsers
            {
                Id = 1, Pseudo = "Rhenar", Mail="hugo.chassaing@orange.fr", Score = 0, AssignedChalls = "{}", ChkPassword = "a7e4ec9e259246db346ac88b10f32901", TeamId = 999
            },
            new CTFUsers
            {
                Id = 2, Pseudo = "AnasBaroudi", Mail="anas.baroudipro@gmail.com", Score = 0, AssignedChalls = "{0}", ChkPassword = "a7e4ec9e259246db346ac88b10f32901", TeamId = 1
            },
            new CTFUsers
            {
                Id = 3, Pseudo = "ClementFranqueville", Mail="clement.franqueville@gmail.com", Score = 0, AssignedChalls = "{0}", ChkPassword = "a7e4ec9e259246db346ac88b10f32901", TeamId = 1
            },
            new CTFUsers
            {
                Id = 4, Pseudo = "TitouanCarn", Mail="titouancarn71@gmail.com", Score = 0, AssignedChalls = "{0}", ChkPassword = "a7e4ec9e259246db346ac88b10f32901", TeamId = 1
            },
            new CTFUsers
            {
                Id = 5, Pseudo = "YanisMakdoud", Mail="yanismakdoud@hotmail.com", Score = 0, AssignedChalls = "{0}", ChkPassword = "a7e4ec9e259246db346ac88b10f32901", TeamId = 1
            },
            new CTFUsers
            {
                Id = 6, Pseudo = "NoraBrahami", Mail="nora.brahami@etu.u-pec.fr", Score = 0, AssignedChalls = "{0}", ChkPassword = "a7e4ec9e259246db346ac88b10f32901", TeamId = 1
            },
            new CTFUsers
            {
                Id = 7, Pseudo = "MaryamBrahami", Mail="maryam.hanou@gmail.com", Score = 0, AssignedChalls = "{0}", ChkPassword = "a7e4ec9e259246db346ac88b10f32901", TeamId = 1
            },
            new CTFUsers
            {
                Id = 8, Pseudo = "LinaBoudjettou", Mail="lina.boudjettou@gmail.com", Score = 0, AssignedChalls = "{0}", ChkPassword = "a7e4ec9e259246db346ac88b10f32901", TeamId = 2
            },
            new CTFUsers
            {
                Id = 9, Pseudo = "LahnaOuld", Mail="lahna.ould@hotmail.com", Score = 0, AssignedChalls = "{0}", ChkPassword = "a7e4ec9e259246db346ac88b10f32901", TeamId = 2
            },
            new CTFUsers
            {
                Id = 10, Pseudo = "ErwanAhmed", Mail="erwan.ahmed94@gmail.com", Score = 0, AssignedChalls = "{0}", ChkPassword = "a7e4ec9e259246db346ac88b10f32901", TeamId = 2
            },
            new CTFUsers
            {
                Id = 11, Pseudo = "BouchraHebbal", Mail="hebbalbouchra@gmail.com", Score = 0, AssignedChalls = "{0}", ChkPassword = "a7e4ec9e259246db346ac88b10f32901", TeamId = 2
            },
            new CTFUsers
            {
                Id = 12, Pseudo = "SamirAmara", Mail="samir.amara2207@gmail.com", Score = 0, AssignedChalls = "{0}", ChkPassword = "a7e4ec9e259246db346ac88b10f32901", TeamId = 2
            },
            new CTFUsers
            {
                Id = 13, Pseudo = "CassandreCanvot", Mail="cassandre.canvot@etu.u-pec.fr", Score = 0, AssignedChalls = "{0}", ChkPassword = "a7e4ec9e259246db346ac88b10f32901", TeamId = 2
            },
            new CTFUsers
            {
                Id = 14, Pseudo = "KrithikaYasonthiram", Mail="krithika.yasonthiram@etu.u-pec.fr", Score = 0, AssignedChalls = "{0}", ChkPassword = "a7e4ec9e259246db346ac88b10f32901", TeamId = 3
            },
            new CTFUsers
            {
                Id = 15, Pseudo = "CallistaChapelle", Mail="callista.chapelle@etu.u-pec.fr", Score = 0, AssignedChalls = "{0}", ChkPassword = "a7e4ec9e259246db346ac88b10f32901", TeamId = 3
            },
            new CTFUsers
            {
                Id = 16, Pseudo = "IlyesHmadi", Mail="ilyes.hmadi@etu.u-pec.fr", Score = 0, AssignedChalls = "{0}", ChkPassword = "a7e4ec9e259246db346ac88b10f32901", TeamId = 3
            },
            new CTFUsers
            {
                Id = 17, Pseudo = "LukasDreyer", Mail="lukas.dreyer@etu.u-pec.fr", Score = 0, AssignedChalls = "{0}", ChkPassword = "a7e4ec9e259246db346ac88b10f32901", TeamId = 3
            },
            new CTFUsers
            {
                Id = 18, Pseudo = "CynthiaSabathier", Mail="cynthia.sabathier@gmail.com", Score = 0, AssignedChalls = "{0}", ChkPassword = "a7e4ec9e259246db346ac88b10f32901", TeamId = 3
            },
            new CTFUsers
            {
                Id = 19, Pseudo = "CoralieCerson", Mail="coralie.cerson@etu.u-pec.fr", Score = 0, AssignedChalls = "{0}", ChkPassword = "a7e4ec9e259246db346ac88b10f32901", TeamId = 3
            },
            new CTFUsers
            {
                Id = 20, Pseudo = "AxelDavidLebastard", Mail="axel.david-lebastard@etu.u-pec.fr", Score = 0, AssignedChalls = "{0}", ChkPassword = "a7e4ec9e259246db346ac88b10f32901", TeamId = 4
            },
            new CTFUsers
            {
                Id = 21, Pseudo = "ThibaultBouchet", Mail="thibault.bouchet@etu.u-pec.fr", Score = 0, AssignedChalls = "{0}", ChkPassword = "a7e4ec9e259246db346ac88b10f32901", TeamId = 4
            },
            new CTFUsers
            {
                Id = 22, Pseudo = "JamesBlainville", Mail="james.blainville@etu.u-pec.fr", Score = 0, AssignedChalls = "{0}", ChkPassword = "a7e4ec9e259246db346ac88b10f32901", TeamId = 4
            },
            new CTFUsers
            {
                Id = 23, Pseudo = "AlexLe", Mail="alex.le@etu.u-pec.fr", Score = 0, AssignedChalls = "{0}", ChkPassword = "a7e4ec9e259246db346ac88b10f32901", TeamId = 4
            },
            new CTFUsers
            {
                Id = 24, Pseudo = "JuliePereira", Mail="julie.pereira@etu.u-pec.fr", Score = 0, AssignedChalls = "{0}", ChkPassword = "a7e4ec9e259246db346ac88b10f32901", TeamId = 4
            },
            new CTFUsers
            {
                Id = 25, Pseudo = "UlricSieys", Mail="ulric.sieys@etu.u-pec.fr", Score = 0, AssignedChalls = "{0}", ChkPassword = "a7e4ec9e259246db346ac88b10f32901", TeamId = 4
            },
            new CTFUsers
            {
                Id = 26, Pseudo = "Saber", Mail="saber.sakkhal@oteria.fr", Score = 0, AssignedChalls = "{}", ChkPassword = "a7e4ec9e259246db346ac88b10f32901", TeamId = 999
            },
            new CTFUsers
            {
                Id = 27, Pseudo = "Valentine", Mail="valentine.pernot@oteria.fr", Score = 0, AssignedChalls = "{}", ChkPassword = "a7e4ec9e259246db346ac88b10f32901", TeamId = 999
            }
        };
    }
    
    private List<CTFTeams> GetCTFTeams()
    {
        return new List<CTFTeams>
        {
            new CTFTeams
            {
                Id = 1, Name = "IA Runners", Score = 0, Members = "{2, 3, 4, 5, 6, 7}", ChkPassword = "a7e4ec9e259246db346ac88b10f32901", ChallsSucceed = "[{\"etaId\": [0]}]"
            },
            new CTFTeams
            {
                Id = 2, Name = "PINMODE", Score = 0, Members = "{8, 9, 10, 11, 12}", ChkPassword = "a7e4ec9e259246db346ac88b10f32901", ChallsSucceed = "[{\"etaId\": [0]}]"
            },
            new CTFTeams
            {
                Id = 3, Name = "2C2K", Score = 0, Members = "{13, 14, 15, 16, 17, 18, 19, 20}", ChkPassword = "a7e4ec9e259246db346ac88b10f32901", ChallsSucceed = "[{\"etaId\": [0]}]"
            },
            new CTFTeams
            {
                Id = 4, Name = "Les poulets", Score = 0, Members = "{21, 22}", ChkPassword = "a7e4ec9e259246db346ac88b10f32901", ChallsSucceed = "[{\"etaId\": [0]}]"
            },
            new CTFTeams
            {
                Id = 999, Name = "Admin", Score = 0, Members = "{1, 26, 27}", ChkPassword = "a7e4ec9e259246db346ac88b10f32901", ChallsSucceed = "[{\"etaId\": [0]}]"
            }
        };
    }
    
    private List<CTFChalls> GetCTFChalls()
    {
        return new List<CTFChalls>
        {
            new CTFChalls
            {
                Id = 1, Name = "Avis de recherche", Actif = true, IDCategories = 1, Image = "https://media.discordapp.net/attachments/1023901955510247484/1118145598164570202/test.jpg?width=1400&height=1000"
            },
            new CTFChalls
            {
                Id = 2, Name = "Timing Attack", Actif = true, IDCategories = 2, Image = "https://kagi.com/proxy/python-img-113865.png?c=voW4nu_Ss_siAJXayRlkd1x6ooI6OHxRvSyWT_gIo5cJ9MDibh3pf9mualar0kQOZVl9EAKxRXOwXQWgenkgRGVEJgEe797Fn0n7onmLjFM%3D"
            },
            new CTFChalls
            {
                Id = 3, Name = "Target : Admin", Actif = true, IDCategories = 2, Image = "https://kagi.com/proxy/avalanche.gif?c=fRA6D874CkqQBEO81ob1I4iGGnwAjsUJVE65fgh7TvB_OM0tNdzWIc0bk3roArcSUsFMQpHnQqnb5CfpcA6jpT_TCtYEW9ebLy9L3XCHP5M%3D"
            },
            new CTFChalls
            {
                Id = 4, Name = "6602", Actif = true, IDCategories = 3, Image = "https://kagi.com/proxy/criquet-oreille-cauchemar-jiminy.gif?c=qCsIsNsCPK2EG-5tqKDsPj-nT0VC9UFMOm38yykNCVkMmpcP4jc6JopGXpUWDdX4Zp9qVd8JYA831XDwJs98cuVEq_vudsAI4CJ4kmetM7Wyw9MgTpIDgubGtZScdD1wPo2jx281jSQc1jrj0kKCxQ%3D%3D"
            }
        };
    }
    
    private List<CTFCategories> GetCTFCategories()
    {
        return new List<CTFCategories>
        {
            new CTFCategories
            {
                Id = 1, Name = "OSINT"
            },
            new CTFCategories
            {
                Id = 2, Name = "Web"
            },
            new CTFCategories
            {
                Id = 3, Name = "OT"
            }
        };
    }
    
    private List<CTFEtapes> GetCTFEtapes()
    {
        return new List<CTFEtapes>
        {
            new CTFEtapes
            {
                Id = 1, Name = "Mystérieux Bobby", Actif = true, Description = "A ce qu'il parait vous avez du talent pour retrouver les gens, ça tombe bien, nous cherchons ce genre de talent.\nUn étudiant de l'IAE, Bobby Latrouille, a soudainement disparu, sur ordre de Philippe Lépinard nous vous demandons d'enquêter sur son cas et de le retrouver.\n\nOn a entendu qu'il était sur des réseaux sociaux, trouvez ses comptes, il y aura surement des informations capitales pour l'enquête\n\nFormat du flag: OTH{exemple_de_flag}", Flag = "OTH{c_3s5_mo1_w3sh}", Img = "https://media.discordapp.net/attachments/1023901955510247484/1118106682128613437/Black_and_White_Simple_Framed_Wanted_Poster.png?width=824&height=1166", LinkedChalls = 1, Order = 1, Points = 100, Categorie = "OSINT"
            },
            new CTFEtapes
            {
                Id = 2, Name = "Un peu de soleil ?", Actif = true, Description = "Bon travail jeune pousse ! On est sur une bonne piste pour le retrouver.\nIl parle de ses dernières vacances sur son Twitter.\nQuelle est l'adresse de cette maison ? Bobby a sympathisé avec le gérant du lieu, où était ce dernier en février 2020 ? Il a trouvé le chien de la famille super mignon, de quelle race était-il ?\n\nFormat du flag: OTH{ville_race} ", Flag = "OTH{courchevel_cocker}", Img = "https://media.discordapp.net/attachments/1023901955510247484/1118103599147405352/challOsintPhoto2.jpg?width=1340&height=880", LinkedChalls = 1, Order = 2, Points = 150, Categorie = "OSINT"
            },
            new CTFEtapes
            {
                Id = 3, Name = "Etrange fichier", Actif = true, Description = "Bobby, dans sa cavale, s’est fait attraper à la frontière d’un pays européen.\nNous avons reçu une clé USB étrange de la part de la douane qui avait fouillé notre cible.\nIl doit forcément y avoir des pistes…vous y comprenez quelque chose vous ?\n\nFormat du flag: OTH{flag_trop_cool}", Flag = "OTH{d3caler_c3st_l0urd}", Img = "https://media.discordapp.net/attachments/1023901955510247484/1118104146894143488/challOsintPhoto3.jpg?width=1554&height=1166", LinkedChalls = 1, Order = 3, Points = 200, Categorie = "OSINT"
            },
            new CTFEtapes
            {
                Id = 4, Name = "La belle époque", Actif = true, Description = "La douane nous a fourni des informations complémentaires. Ils ont réussi à exfiltrer certaines images de son téléphone. \nPouvez-vous trouver le collège où Bobby a fait sa scolarité ?\n\nFormat du flag: OTH{college_rene_malleville}", Flag = "OTH{college_andre_chenier}", Img = "https://media.discordapp.net/attachments/1023901955510247484/1118104418211086396/challOsintPhoto4.png?width=1864&height=1164", LinkedChalls = 1, Order = 4, Points = 250, Categorie = "OSINT"
            },
            new CTFEtapes
            {
                Id = 5, Name = "Un complice ?", Actif = true, Description = "Bobby parle d'une professeur qu'il a eu pendant sa période lycée sur son Twitter.\nNous devons la retrouver pour lui poser des questions, peut-être a-t-elle eu un contact avec lui récemment ?\n\nFormat du flag: OTH{prenom_nom}", Flag = "OTH{isabelle_balard}", Img = "https://media.discordapp.net/attachments/1023901955510247484/1118104750852931584/challOsintPhoto5.jpg?width=1748&height=1166", LinkedChalls = 1, Order = 5, Points = 300, Categorie = "OSINT"
            },
            new CTFEtapes
            {
                Id = 6, Name = "L'ultime révélation", Actif = true, Description = "Bobby et son professeur se sont donnés rendez-vous pour se voir après de longues années, en lui parlant d’un “ lourd secret “ dont il devait lui faire part. Malheureusement, il n’a pas pu se rendre sur le lieu du rendez-vous, alors il a laissé un message pour son professeur sur ce même lieu, entre les mains de l’hôtesse qui garde ce lieu. Allez intercepter le message avant que son professeur ne le récupère.\n\nPour retrouver le lieu, voici le message de Bobby a son professeur lorsqu’il lui a donné rendez-vous :\n\"Je vous propose que l’on se voie dans l’accueil de l’entreprise qui devait m’accueillir pour un contrat d’apprentissage. Elle se trouve dans le bâtiment Clever, et son logo est de teinte bleue. Le PDG a un nom à consonance hollandaise \"\n\nAttention, pour espérer récupérer le message, faites vous passer pour la fille/fils de Isabelle :)\nFormat du flag : OTH{bouhbouh}", Flag = "OTH{b0bby_3st_r1ch3}", Img = "https://media.discordapp.net/attachments/1023901955510247484/1118105763966095360/challOsintPhoto6.gif?width=1280&height=848", LinkedChalls = 1, Order = 6, Points = 350, Categorie = "OSINT"
            },
            new CTFEtapes
            {
                Id = 7, Name = "Timing Attack", Actif = true, Description = "Sortez votre meilleur éditeur de texte car ça va scripter fort...\n\nFormat du flag : OTH{bouhbouh}", Flag = "OTH{hPM5OfVV73}", Img = "https://kagi.com/proxy/python-img-113865.png?c=voW4nu_Ss_siAJXayRlkd1x6ooI6OHxRvSyWT_gIo5cJ9MDibh3pf9mualar0kQOZVl9EAKxRXOwXQWgenkgRGVEJgEe797Fn0n7onmLjFM%3D", LinkedChalls = 2, Order = 1, Points = 500, Categorie = "Web"
            },
            new CTFEtapes
            {
                Id = 8, Name = "Request Avalanche", Actif = true, Description = "Bon bon bon, c'est où déjà ce truc ?...\n\nFormat du flag : OTH{user_password}", Flag = "OTH{Jason_MonSuperMotDeP@sse}", Img = "https://kagi.com/proxy/avalanche.gif?c=fRA6D874CkqQBEO81ob1I4iGGnwAjsUJVE65fgh7TvB_OM0tNdzWIc0bk3roArcSUsFMQpHnQqnb5CfpcA6jpT_TCtYEW9ebLy9L3XCHP5M%3D", LinkedChalls = 3, Order = 1, Points = 250, Categorie = "Web"
            },
            new CTFEtapes
            {
                Id = 9, Name = "JWT", Actif = true, Description = "Deux biscuits dans un four. Un cookie se tourne vers l'autre cookie et dit, il fait vraiment chaud ici.\nL'autre cookie crie, Ahhh ! Un cookie qui parle !\n\nFormat du flag : OTH{bouhbouh}", Flag = "OTH{B3c@rfuL_w1tH_Jwt_1n_Pr0D}", Img = "https://kagi.com/proxy/avalanche.gif?c=fRA6D874CkqQBEO81ob1I4iGGnwAjsUJVE65fgh7TvB_OM0tNdzWIc0bk3roArcSUsFMQpHnQqnb5CfpcA6jpT_TCtYEW9ebLy9L3XCHP5M%3D", LinkedChalls = 3, Order = 2, Points = 400, Categorie = "Web"
            },
            new CTFEtapes
            {
                Id = 10, Name = "The Entry", Actif = true, Description = "Vous venez de recevoir une mystérieuse image et vous savez qu'elle cache quelque chose... peut-être qu'en fouillant dedans...\n\nFormat du flag : OTH{Ym9uam91cmxlc2xvdXN0aXF1ZXN2b3Vzc2F2ZXpxdWV2b3Vz6nRlc2Ryb2xlPw==}", Flag = "OTH{aHR0cDovL2JsdWUtcHJvamVjdC5jbzpYWFhYL2luZGV4Lmh0bWw=}", Img = "https://kagi.com/proxy/criquet-oreille-cauchemar-jiminy.gif?c=qCsIsNsCPK2EG-5tqKDsPj-nT0VC9UFMOm38yykNCVkMmpcP4jc6JopGXpUWDdX4Zp9qVd8JYA831XDwJs98cuVEq_vudsAI4CJ4kmetM7Wyw9MgTpIDgubGtZScdD1wPo2jx281jSQc1jrj0kKCxQ%3D%3D", LinkedChalls = 4, Order = 1, Points = 50, Categorie = "OT"
            },
            new CTFEtapes
            {
                Id = 11, Name = "Outguess", Actif = true, Description = "Il semblerait qu'ils adorent les images ici ! Encore une autre... \n\nFormat du flag : OTH{fezfzefzefze.onion}", Flag = "OTH{loqt6lh5n6wezgetjjhgz7ps43bsvwv3gz75onsbmvqpchqqmj3kwzyd.onion}", Img = "https://kagi.com/proxy/latest?c=KuL4k4ESLwwqNjT2PZ7j6wo1XWKHMG-wlO-H94mCuQtna7sY6pang3SFZGs3Egq9ocolsPf6VY2xYpBFy-xHQFxLhE_l5oEZZdzXuO_mvT8txNU1-H0hLLl6POsM_TCM25fRRptkTAsXv9NGpWK4FySG0VioKCvvVlNrYqXSsWU%3D", LinkedChalls = 4, Order = 2, Points = 150, Categorie = "OT"
            },
            new CTFEtapes
            {
                Id = 12, Name = "SQL Here I Come", Actif = true, Description = "Maintenant faut s'identifier ??? Et puis quoi encore ? \n\nFormat du flag : OTH{feozpfjeziofnzf.html}", Flag = "OTH{f60626d86938f3df8cbc2e53f7a1ad1154a5c6ba.html}", Img = "https://kagi.com/proxy/identifier-les-references-d-un-outil-electroportatif-000676004-product_zoom.jpg?c=-eIzMiD35CJre_o-hD2FBAfCytz7MygLWUcxuhGcitVt4GyO_9Cn3auasH_gPSDv5-rizDI6x2WQHPb6KBj_WvBXUKnkjcwdTWDsesPH_LLBLMGm0k6lffJDiURxHlEYslHI0bLgtl02yIPlt5blMO3VBwuauM8AMJX9mSlrmQxqgHjhe6efrmwoQQsAn-3j", LinkedChalls = 4, Order = 3, Points = 150, Categorie = "OT"
            }
        };
    }
    
    private List<CTFGlobal> GetCTFGlobal()
    {
        return new List<CTFGlobal>
        {
            new CTFGlobal
            {
                Id = 1, Duration = "2023-06-14 18:00:00"
            }
        };
    }

}