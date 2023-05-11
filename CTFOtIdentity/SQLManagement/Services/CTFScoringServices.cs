using CTFOt.SQLManagement.Definitions;
using CTFOt.SQLManagement.Context;
using Microsoft.EntityFrameworkCore;

namespace CTFOt.SQLManagement.Services;

public interface ICTFScoringServices
{
    Task<List<CTFScoring>> GetScoringAsync();
    Task<CTFScoring> AddScoringAsync(CTFScoring scoring);
    Task<CTFScoring> UpdateScoringAsync(CTFScoring scoring);
    Task DeleteScoringAsync(CTFScoring scoring);
    List<CTFScoring> GetScoringByTeam(int TeamsId);
    Task<List<CTFScoring>> GetScoringByTeamAsync(int TeamsId);
    int GetFlagIsDoneOnPlayerWithEtapes(int TeamsId, int etapesId);
    int GetNbFlagDoneByTeam(int TeamId);
}

public class CTFScoringServices : ICTFScoringServices
{
    private CTFContext dbContext;
    
    public CTFScoringServices(CTFContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<List<CTFScoring>> GetScoringAsync()
    {
        return await dbContext.CTFScoring.ToListAsync();
    }

    public async Task<CTFScoring> AddScoringAsync(CTFScoring score)
    {
        try
        {
            dbContext.CTFScoring.Add(score);
            await dbContext.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }

        return score;
    }
    
    public async Task<CTFScoring> UpdateScoringAsync(CTFScoring score)
    {
        try
        {
            var scoreExist = dbContext.CTFScoring.FirstOrDefault(l => l.Id == score.Id);
            if (scoreExist != null)
            {
                dbContext.Update(score);
                await dbContext.SaveChangesAsync();
            }
        }
        catch (Exception)
        {
            throw;
        }

        return score;
    }
    
    public async Task DeleteScoringAsync(CTFScoring score)
    {
        try
        {
            dbContext.CTFScoring.Remove(score);
            await dbContext.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public int GetFlagIsDoneOnPlayerWithEtapes(int team, int etapes)
    {
        var flagIsDone = dbContext.CTFScoring.Where(l => l.IdTeam == team && l.IdEtape == etapes).Count();
        return flagIsDone;
    }

    public async Task<List<CTFScoring>> GetScoringByTeamAsync(int TeamsId)
    {
        var scoreTeams = dbContext.CTFScoring.Where(l => l.IdTeam == TeamsId).ToList();
        return scoreTeams;
    }
    
    public List<CTFScoring> GetScoringByTeam(int TeamsId)
    {
        var scoreTeams = dbContext.CTFScoring.Where(l => l.IdTeam == TeamsId).ToList();
        return scoreTeams;
    }

    public int GetNbFlagDoneByTeam(int teamid)
    {
        var nbFlagDone = dbContext.CTFScoring.Where(l => l.IdTeam == teamid).Count();
        return nbFlagDone;
    }
    
}