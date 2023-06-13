using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CTFOtIdentity.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CTFCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CTFCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CTFChalls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    IDCategories = table.Column<int>(type: "INTEGER", nullable: false),
                    Image = table.Column<string>(type: "TEXT", nullable: false),
                    Actif = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CTFChalls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CTFEtapes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Flag = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Img = table.Column<string>(type: "TEXT", nullable: false),
                    Points = table.Column<int>(type: "INTEGER", nullable: false),
                    Order = table.Column<int>(type: "INTEGER", nullable: false),
                    LinkedChalls = table.Column<int>(type: "INTEGER", nullable: false),
                    Actif = table.Column<bool>(type: "INTEGER", nullable: false),
                    Categorie = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CTFEtapes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CTFGlobal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Duration = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CTFGlobal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CTFRessources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Link = table.Column<string>(type: "TEXT", nullable: false),
                    IdAssociatedEta = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CTFRessources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CTFScoring",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdTeam = table.Column<int>(type: "INTEGER", nullable: false),
                    IdEtape = table.Column<int>(type: "INTEGER", nullable: false),
                    IdPlayer = table.Column<int>(type: "INTEGER", nullable: false),
                    Points = table.Column<int>(type: "INTEGER", nullable: false),
                    DateTime = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CTFScoring", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CTFTeams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ChkPassword = table.Column<string>(type: "TEXT", nullable: false),
                    ChallsSucceed = table.Column<string>(type: "TEXT", nullable: false),
                    Members = table.Column<string>(type: "TEXT", nullable: false),
                    Score = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CTFTeams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CTFUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Pseudo = table.Column<string>(type: "TEXT", nullable: false),
                    Mail = table.Column<string>(type: "TEXT", nullable: false),
                    ChkPassword = table.Column<string>(type: "TEXT", nullable: false),
                    Score = table.Column<long>(type: "INTEGER", nullable: false),
                    AssignedChalls = table.Column<string>(type: "TEXT", nullable: false),
                    TeamId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CTFUsers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CTFCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "OSINT" },
                    { 2, "Web" },
                    { 3, "OT" }
                });

            migrationBuilder.InsertData(
                table: "CTFChalls",
                columns: new[] { "Id", "Actif", "IDCategories", "Image", "Name" },
                values: new object[,]
                {
                    { 1, true, 1, "https://media.discordapp.net/attachments/1023901955510247484/1118145598164570202/test.jpg?width=1400&height=1000", "Avis de recherche" },
                    { 2, true, 2, "https://kagi.com/proxy/python-img-113865.png?c=voW4nu_Ss_siAJXayRlkd1x6ooI6OHxRvSyWT_gIo5cJ9MDibh3pf9mualar0kQOZVl9EAKxRXOwXQWgenkgRGVEJgEe797Fn0n7onmLjFM%3D", "Timing Attack" },
                    { 3, true, 2, "https://kagi.com/proxy/avalanche.gif?c=fRA6D874CkqQBEO81ob1I4iGGnwAjsUJVE65fgh7TvB_OM0tNdzWIc0bk3roArcSUsFMQpHnQqnb5CfpcA6jpT_TCtYEW9ebLy9L3XCHP5M%3D", "Target : Admin" },
                    { 4, true, 3, "https://kagi.com/proxy/criquet-oreille-cauchemar-jiminy.gif?c=qCsIsNsCPK2EG-5tqKDsPj-nT0VC9UFMOm38yykNCVkMmpcP4jc6JopGXpUWDdX4Zp9qVd8JYA831XDwJs98cuVEq_vudsAI4CJ4kmetM7Wyw9MgTpIDgubGtZScdD1wPo2jx281jSQc1jrj0kKCxQ%3D%3D", "6602" }
                });

            migrationBuilder.InsertData(
                table: "CTFEtapes",
                columns: new[] { "Id", "Actif", "Categorie", "Description", "Flag", "Img", "LinkedChalls", "Name", "Order", "Points" },
                values: new object[,]
                {
                    { 1, true, "OSINT", "A ce qu'il parait vous avez du talent pour retrouver les gens, ça tombe bien, nous cherchons ce genre de talent.\nUn étudiant de l'IAE, Bobby Latrouille, a soudainement disparu, sur ordre de Philippe Lépinard nous vous demandons d'enquêter sur son cas et de le retrouver.\n\nOn a entendu qu'il était sur des réseaux sociaux, trouvez ses comptes, il y aura surement des informations capitales pour l'enquête\n\nFormat du flag: OTH{exemple_de_flag}", "OTH{c_3s5_mo1_w3sh}", "https://media.discordapp.net/attachments/1023901955510247484/1118106682128613437/Black_and_White_Simple_Framed_Wanted_Poster.png?width=824&height=1166", 1, "Mystérieux Bobby", 1, 100 },
                    { 2, true, "OSINT", "Bon travail jeune pousse ! On est sur une bonne piste pour le retrouver.\nIl parle de ses dernières vacances sur son Twitter.\nQuelle est l'adresse de cette maison ? Bobby a sympathisé avec le gérant du lieu, où était ce dernier en février 2020 ? Il a trouvé le chien de la famille super mignon, de quelle race était-il ?\n\nFormat du flag: OTH{ville_race} ", "OTH{courchevel_cocker}", "https://media.discordapp.net/attachments/1023901955510247484/1118103599147405352/challOsintPhoto2.jpg?width=1340&height=880", 1, "Un peu de soleil ?", 2, 150 },
                    { 3, true, "OSINT", "Bobby, dans sa cavale, s’est fait attraper à la frontière d’un pays européen.\nNous avons reçu une clé USB étrange de la part de la douane qui avait fouillé notre cible.\nIl doit forcément y avoir des pistes…vous y comprenez quelque chose vous ?\n\nFormat du flag: OTH{flag_trop_cool}", "OTH{d3caler_c3st_l0urd}", "https://media.discordapp.net/attachments/1023901955510247484/1118104146894143488/challOsintPhoto3.jpg?width=1554&height=1166", 1, "Etrange fichier", 3, 200 },
                    { 4, true, "OSINT", "La douane nous a fourni des informations complémentaires. Ils ont réussi à exfiltrer certaines images de son téléphone. \nPouvez-vous trouver le collège où Bobby a fait sa scolarité ?\n\nFormat du flag: OTH{college_rene_malleville}", "OTH{college_andre_chenier}", "https://media.discordapp.net/attachments/1023901955510247484/1118104418211086396/challOsintPhoto4.png?width=1864&height=1164", 1, "La belle époque", 4, 250 },
                    { 5, true, "OSINT", "Bobby parle d'une professeur qu'il a eu pendant sa période lycée sur son Twitter.\nNous devons la retrouver pour lui poser des questions, peut-être a-t-elle eu un contact avec lui récemment ?\n\nFormat du flag: OTH{prenom_nom}", "OTH{isabelle_balard}", "https://media.discordapp.net/attachments/1023901955510247484/1118104750852931584/challOsintPhoto5.jpg?width=1748&height=1166", 1, "Un complice ?", 5, 300 },
                    { 6, true, "OSINT", "Bobby et son professeur se sont donnés rendez-vous pour se voir après de longues années, en lui parlant d’un “ lourd secret “ dont il devait lui faire part. Malheureusement, il n’a pas pu se rendre sur le lieu du rendez-vous, alors il a laissé un message pour son professeur sur ce même lieu, entre les mains de l’hôtesse qui garde ce lieu. Allez intercepter le message avant que son professeur ne le récupère.\n\nPour retrouver le lieu, voici le message de Bobby a son professeur lorsqu’il lui a donné rendez-vous :\n\"Je vous propose que l’on se voie dans l’accueil de l’entreprise qui devait m’accueillir pour un contrat d’apprentissage. Elle se trouve dans le bâtiment Clever, et son logo est de teinte bleue. Le PDG a un nom à consonance hollandaise \"\n\nAttention, pour espérer récupérer le message, faites vous passer pour la fille/fils de Isabelle :)\nFormat du flag : OTH{bouhbouh}", "OTH{b0bby_3st_r1ch3}", "https://media.discordapp.net/attachments/1023901955510247484/1118105763966095360/challOsintPhoto6.gif?width=1280&height=848", 1, "L'ultime révélation", 6, 350 },
                    { 7, true, "Web", "Sortez votre meilleur éditeur de texte car ça va scripter fort...\n\nFormat du flag : OTH{bouhbouh}", "OTH{hPM5OfVV73}", "https://kagi.com/proxy/python-img-113865.png?c=voW4nu_Ss_siAJXayRlkd1x6ooI6OHxRvSyWT_gIo5cJ9MDibh3pf9mualar0kQOZVl9EAKxRXOwXQWgenkgRGVEJgEe797Fn0n7onmLjFM%3D", 2, "Timing Attack", 1, 500 },
                    { 8, true, "Web", "Bon bon bon, c'est où déjà ce truc ?...\n\nFormat du flag : OTH{user_password}", "OTH{Jason_MonSuperMotDeP@sse}", "https://kagi.com/proxy/avalanche.gif?c=fRA6D874CkqQBEO81ob1I4iGGnwAjsUJVE65fgh7TvB_OM0tNdzWIc0bk3roArcSUsFMQpHnQqnb5CfpcA6jpT_TCtYEW9ebLy9L3XCHP5M%3D", 3, "Request Avalanche", 1, 250 },
                    { 9, true, "Web", "Deux biscuits dans un four. Un cookie se tourne vers l'autre cookie et dit, il fait vraiment chaud ici.\nL'autre cookie crie, Ahhh ! Un cookie qui parle !\n\nFormat du flag : OTH{bouhbouh}", "OTH{B3c@rfuL_w1tH_Jwt_1n_Pr0D}", "https://kagi.com/proxy/avalanche.gif?c=fRA6D874CkqQBEO81ob1I4iGGnwAjsUJVE65fgh7TvB_OM0tNdzWIc0bk3roArcSUsFMQpHnQqnb5CfpcA6jpT_TCtYEW9ebLy9L3XCHP5M%3D", 3, "JWT", 2, 400 },
                    { 10, true, "OT", "Vous venez de recevoir une mystérieuse image et vous savez qu'elle cache quelque chose... peut-être qu'en fouillant dedans...\n\nFormat du flag : OTH{Ym9uam91cmxlc2xvdXN0aXF1ZXN2b3Vzc2F2ZXpxdWV2b3Vz6nRlc2Ryb2xlPw==}", "OTH{aHR0cDovL2JsdWUtcHJvamVjdC5jbzpYWFhYL2luZGV4Lmh0bWw=}", "https://kagi.com/proxy/criquet-oreille-cauchemar-jiminy.gif?c=qCsIsNsCPK2EG-5tqKDsPj-nT0VC9UFMOm38yykNCVkMmpcP4jc6JopGXpUWDdX4Zp9qVd8JYA831XDwJs98cuVEq_vudsAI4CJ4kmetM7Wyw9MgTpIDgubGtZScdD1wPo2jx281jSQc1jrj0kKCxQ%3D%3D", 4, "The Entry", 1, 50 },
                    { 11, true, "OT", "Il semblerait qu'ils adorent les images ici ! Encore une autre... \n\nFormat du flag : OTH{fezfzefzefze.onion}", "OTH{loqt6lh5n6wezgetjjhgz7ps43bsvwv3gz75onsbmvqpchqqmj3kwzyd.onion}", "https://kagi.com/proxy/latest?c=KuL4k4ESLwwqNjT2PZ7j6wo1XWKHMG-wlO-H94mCuQtna7sY6pang3SFZGs3Egq9ocolsPf6VY2xYpBFy-xHQFxLhE_l5oEZZdzXuO_mvT8txNU1-H0hLLl6POsM_TCM25fRRptkTAsXv9NGpWK4FySG0VioKCvvVlNrYqXSsWU%3D", 4, "Outguess", 2, 150 },
                    { 12, true, "OT", "Maintenant faut s'identifier ??? Et puis quoi encore ? \n\nFormat du flag : OTH{feozpfjeziofnzf.html}", "OTH{f60626d86938f3df8cbc2e53f7a1ad1154a5c6ba.html}", "https://kagi.com/proxy/identifier-les-references-d-un-outil-electroportatif-000676004-product_zoom.jpg?c=-eIzMiD35CJre_o-hD2FBAfCytz7MygLWUcxuhGcitVt4GyO_9Cn3auasH_gPSDv5-rizDI6x2WQHPb6KBj_WvBXUKnkjcwdTWDsesPH_LLBLMGm0k6lffJDiURxHlEYslHI0bLgtl02yIPlt5blMO3VBwuauM8AMJX9mSlrmQxqgHjhe6efrmwoQQsAn-3j", 4, "SQL Here I Come", 3, 150 }
                });

            migrationBuilder.InsertData(
                table: "CTFGlobal",
                columns: new[] { "Id", "Duration" },
                values: new object[] { 1, "2023-06-14 18:00:00" });

            migrationBuilder.InsertData(
                table: "CTFRessources",
                columns: new[] { "Id", "IdAssociatedEta", "Link", "Name", "Type" },
                values: new object[,]
                {
                    { 1, 3, "https://cdn.discordapp.com/attachments/850005023218991105/1115609930272088095/weird_file.wav", "weird_file.wav", "FILES" },
                    { 2, 4, "https://media.discordapp.net/attachments/850005023218991105/1115610729173762208/image1.png?width=1220&height=1166", "image1.png", "FILES" },
                    { 3, 4, "https://media.discordapp.net/attachments/850005023218991105/1115610728397799474/image2.png?width=1062&height=1166", "image2.png", "FILES" },
                    { 4, 7, "http://192.168.208.17/", "Site Web", "LINK" },
                    { 5, 8, "http://192.168.208.18/", "Site Web", "LINK" },
                    { 6, 9, "http://192.168.208.18/", "Site Web", "LINK" },
                    { 7, 10, "http://192.168.208.16/img.png", "6602", "FILES" }
                });

            migrationBuilder.InsertData(
                table: "CTFScoring",
                columns: new[] { "Id", "DateTime", "IdEtape", "IdPlayer", "IdTeam", "Points" },
                values: new object[,]
                {
                    { 1, "2023-06-14 15:30:00", 999, 1, 1, 0 },
                    { 2, "2023-06-14 15:30:00", 999, 8, 2, 0 },
                    { 3, "2023-06-14 15:30:00", 999, 16, 3, 0 }
                });

            migrationBuilder.InsertData(
                table: "CTFTeams",
                columns: new[] { "Id", "ChallsSucceed", "ChkPassword", "Members", "Name", "Score" },
                values: new object[,]
                {
                    { 1, "[{\"etaId\": [0]}]", "a7e4ec9e259246db346ac88b10f32901", "{2, 3, 4, 5, 6, 7}", "IA Runners", 0 },
                    { 2, "[{\"etaId\": [0]}]", "a7e4ec9e259246db346ac88b10f32901", "{8, 9, 10, 11, 12}", "PINMODE", 0 },
                    { 3, "[{\"etaId\": [0]}]", "a7e4ec9e259246db346ac88b10f32901", "{13, 14, 15, 16, 17, 18, 19, 20}", "2C2K", 0 },
                    { 4, "[{\"etaId\": [0]}]", "a7e4ec9e259246db346ac88b10f32901", "{21, 22}", "Les poulets", 0 },
                    { 999, "[{\"etaId\": [0]}]", "a7e4ec9e259246db346ac88b10f32901", "{1, 26, 27}", "Admin", 0 }
                });

            migrationBuilder.InsertData(
                table: "CTFUsers",
                columns: new[] { "Id", "AssignedChalls", "ChkPassword", "Mail", "Pseudo", "Score", "TeamId" },
                values: new object[,]
                {
                    { 1, "{}", "a7e4ec9e259246db346ac88b10f32901", "hugo.chassaing@orange.fr", "Rhenar", 0L, 999 },
                    { 2, "{0}", "a7e4ec9e259246db346ac88b10f32901", "anas.baroudipro@gmail.com", "AnasBaroudi", 0L, 1 },
                    { 3, "{0}", "a7e4ec9e259246db346ac88b10f32901", "clement.franqueville@gmail.com", "ClementFranqueville", 0L, 1 },
                    { 4, "{0}", "a7e4ec9e259246db346ac88b10f32901", "titouancarn71@gmail.com", "TitouanCarn", 0L, 1 },
                    { 5, "{0}", "a7e4ec9e259246db346ac88b10f32901", "yanismakdoud@hotmail.com", "YanisMakdoud", 0L, 1 },
                    { 6, "{0}", "a7e4ec9e259246db346ac88b10f32901", "nora.brahami@etu.u-pec.fr", "NoraBrahami", 0L, 1 },
                    { 7, "{0}", "a7e4ec9e259246db346ac88b10f32901", "maryam.hanou@gmail.com", "MaryamBrahami", 0L, 1 },
                    { 8, "{0}", "a7e4ec9e259246db346ac88b10f32901", "lina.boudjettou@gmail.com", "LinaBoudjettou", 0L, 2 },
                    { 9, "{0}", "a7e4ec9e259246db346ac88b10f32901", "lahna.ould@hotmail.com", "LahnaOuld", 0L, 2 },
                    { 10, "{0}", "a7e4ec9e259246db346ac88b10f32901", "erwan.ahmed94@gmail.com", "ErwanAhmed", 0L, 2 },
                    { 11, "{0}", "a7e4ec9e259246db346ac88b10f32901", "hebbalbouchra@gmail.com", "BouchraHebbal", 0L, 2 },
                    { 12, "{0}", "a7e4ec9e259246db346ac88b10f32901", "samir.amara2207@gmail.com", "SamirAmara", 0L, 2 },
                    { 13, "{0}", "a7e4ec9e259246db346ac88b10f32901", "cassandre.canvot@etu.u-pec.fr", "CassandreCanvot", 0L, 2 },
                    { 14, "{0}", "a7e4ec9e259246db346ac88b10f32901", "krithika.yasonthiram@etu.u-pec.fr", "KrithikaYasonthiram", 0L, 3 },
                    { 15, "{0}", "a7e4ec9e259246db346ac88b10f32901", "callista.chapelle@etu.u-pec.fr", "CallistaChapelle", 0L, 3 },
                    { 16, "{0}", "a7e4ec9e259246db346ac88b10f32901", "ilyes.hmadi@etu.u-pec.fr", "IlyesHmadi", 0L, 3 },
                    { 17, "{0}", "a7e4ec9e259246db346ac88b10f32901", "lukas.dreyer@etu.u-pec.fr", "LukasDreyer", 0L, 3 },
                    { 18, "{0}", "a7e4ec9e259246db346ac88b10f32901", "cynthia.sabathier@gmail.com", "CynthiaSabathier", 0L, 3 },
                    { 19, "{0}", "a7e4ec9e259246db346ac88b10f32901", "coralie.cerson@etu.u-pec.fr", "CoralieCerson", 0L, 3 },
                    { 20, "{0}", "a7e4ec9e259246db346ac88b10f32901", "axel.david-lebastard@etu.u-pec.fr", "AxelDavidLebastard", 0L, 4 },
                    { 21, "{0}", "a7e4ec9e259246db346ac88b10f32901", "thibault.bouchet@etu.u-pec.fr", "ThibaultBouchet", 0L, 4 },
                    { 22, "{0}", "a7e4ec9e259246db346ac88b10f32901", "james.blainville@etu.u-pec.fr", "JamesBlainville", 0L, 4 },
                    { 23, "{0}", "a7e4ec9e259246db346ac88b10f32901", "alex.le@etu.u-pec.fr", "AlexLe", 0L, 4 },
                    { 24, "{0}", "a7e4ec9e259246db346ac88b10f32901", "julie.pereira@etu.u-pec.fr", "JuliePereira", 0L, 4 },
                    { 25, "{0}", "a7e4ec9e259246db346ac88b10f32901", "ulric.sieys@etu.u-pec.fr", "UlricSieys", 0L, 4 },
                    { 26, "{}", "a7e4ec9e259246db346ac88b10f32901", "saber.sakkhal@oteria.fr", "Saber", 0L, 999 },
                    { 27, "{}", "a7e4ec9e259246db346ac88b10f32901", "valentine.pernot@oteria.fr", "Valentine", 0L, 999 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CTFCategories");

            migrationBuilder.DropTable(
                name: "CTFChalls");

            migrationBuilder.DropTable(
                name: "CTFEtapes");

            migrationBuilder.DropTable(
                name: "CTFGlobal");

            migrationBuilder.DropTable(
                name: "CTFRessources");

            migrationBuilder.DropTable(
                name: "CTFScoring");

            migrationBuilder.DropTable(
                name: "CTFTeams");

            migrationBuilder.DropTable(
                name: "CTFUsers");
        }
    }
}
