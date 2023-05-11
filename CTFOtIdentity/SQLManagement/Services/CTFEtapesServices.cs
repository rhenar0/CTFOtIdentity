using CTFOt.SQLManagement.Definitions;
using Microsoft.EntityFrameworkCore;

namespace CTFOt.SQLManagement.Services;
using Definitions;
using Context;

public interface ICTFEtapesServices
{
    Task<List<CTFEtapes>> GetEtapesAsync();
    Task<CTFEtapes> AddEtapesAsync(CTFEtapes etapes);
    Task<CTFEtapes> UpdateEtapesAsync(CTFEtapes etapes);
    Task DeleteEtapesAsync(CTFEtapes etapes);
    Task<int> SubmitFlagAsync(string flag, int userId, int chalId);
    int GetNbActifEtape();
    List<CTFEtapes> GetItCompleted(List<CTFScoring> scoring);
    List<CTFEtapes> GetItNonCompleted(List<CTFEtapes> etapes);
}

public class CTFEtapesServices : ICTFEtapesServices
{
    private CTFContext dbContext;
    
    public CTFEtapesServices(CTFContext dbContext)
    {
        this.dbContext = dbContext;
    }
    
    public async Task<List<CTFEtapes>> GetEtapesAsync()
    {
        return await dbContext.CTFEtapes.ToListAsync();
    }
    
    public async Task<CTFEtapes> AddEtapesAsync(CTFEtapes etapes)
    {
        try
        {
            dbContext.CTFEtapes.Add(etapes);
            await dbContext.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }
        
        return etapes;
    }
    
    public async Task<CTFEtapes> UpdateEtapesAsync(CTFEtapes etapes)
    {
        try
        {
            var EtapesExist = dbContext.CTFEtapes.FirstOrDefault(l => l.Id == etapes.Id);
            if (EtapesExist != null)
            {
                dbContext.Update(etapes);
                await dbContext.SaveChangesAsync();
            }
        }
        catch (Exception)
        {
            throw;
        }
        
        return etapes;
    }

    public async Task<int> SubmitFlagAsync(string flag, int userId, int chalId)
    {
        var usr = dbContext.CTFUsers.FirstOrDefault(l => l.Id == userId);
        dynamic TeamUser = Newtonsoft.Json.JsonConvert.DeserializeObject(dbContext.CTFTeams.FirstOrDefault(l => l.Id == usr.TeamId).ChallsSucceed);
        foreach (var eta in TeamUser[0].etaId)
        {
            if (eta == chalId)
            {
                return 2;
            }
        }
        
        string RFlag;
        try
        {
            RFlag = dbContext.CTFEtapes.FirstOrDefault(l => l.Id == chalId).Flag;
            if (RFlag == flag)
            {
                TeamUser[0].etaId.Add(chalId);
                var team = dbContext.CTFTeams.FirstOrDefault(l => l.Id == usr.TeamId);
                team.ChallsSucceed = Newtonsoft.Json.JsonConvert.SerializeObject(TeamUser);
                dbContext.Update(team);
                
                var user = dbContext.CTFUsers.FirstOrDefault(l => l.Id == userId);
                user.Score += dbContext.CTFEtapes.FirstOrDefault(l => l.Id == chalId).Points;
                dbContext.Update(user);
                
                var etape = dbContext.CTFScoring.OrderBy(l => l.Points).LastOrDefaultAsync(l => l.IdTeam == usr.TeamId);
                
                
                //Add to scoring table + additionnal points
                var score = new CTFScoring();
                score.IdTeam = usr.TeamId;
                score.IdEtape = chalId;
                score.IdPlayer = userId;
                score.Points = dbContext.CTFEtapes.FirstOrDefault(l => l.Id == chalId).Points + etape.Result.Points;
                score.DateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                
                dbContext.CTFScoring.Add(score);

                await dbContext.SaveChangesAsync();
                
                return 1;
            }
        }
        catch (Exception)
        {
            throw;
        }

        return 0;
    }

    public int GetNbActifEtape()
    {
        var etape = dbContext.CTFEtapes.Where(l => l.Actif == true).Count();
        return etape;
    }

    public async Task DeleteEtapesAsync(CTFEtapes etapes)
    {
        try
        {
            dbContext.CTFEtapes.Remove(etapes);
            await dbContext.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public List<CTFEtapes> GetItCompleted(List<CTFScoring> scoring)
    {
        List<CTFEtapes> ReturnValue = new List<CTFEtapes>();
        
        foreach(var a in scoring)
        {
            try
            {
                if (a.Points > 0) {
                    ReturnValue.Add(dbContext.CTFEtapes.Where(l => l.Id == a.IdEtape).FirstOrDefault());
                }
            } catch (Exception e)
            {
                throw;
            }
        }

        return ReturnValue;
    }

    public List<CTFEtapes> GetItNonCompleted(List<CTFEtapes> etapesCompeted)
    {
        List<CTFEtapes> ReturnValue = new List<CTFEtapes>();
        
        foreach(var a in dbContext.CTFEtapes)
        {
            try
            {
                if (!etapesCompeted.Contains(a))
                {
                    ReturnValue.Add(a);
                }
            } catch (Exception e)
            {
                throw;
            }
        }

        return ReturnValue;
    }

}