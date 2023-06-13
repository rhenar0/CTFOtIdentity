using Radzen;

namespace CTFOtIdentity.SQLManagement.Services;

using Microsoft.EntityFrameworkCore;
using Context;
using Definitions;

public interface ICTFTeamServices
{
    Task<List<CTFTeams>> GetTeamsAsync();
    Task<CTFTeams> AddTeamsAsync(CTFTeams teams);
    Task<CTFTeams> UpdateTeamsAsync(CTFTeams teams);
    Task DeleteTeamsAsync(CTFTeams teams);
    Task<List<CTFTeams>> GetTeamsAsyncScoring();
}

public class CTFTeamsServices : ICTFTeamServices 
{
    
    private CTFContext dbContext;
    
    public CTFTeamsServices(CTFContext dbContext)
    {
        this.dbContext = dbContext;
    }
    
    public async Task<List<CTFTeams>> GetTeamsAsync()
    {
        return await dbContext.CTFTeams.ToListAsync();
    }
    
    public async Task<List<CTFTeams>> GetTeamsAsyncScoring()
    {
        return await dbContext.CTFTeams.Where(l => l.Id != 999).ToListAsync();
    }
    
    public async Task<CTFTeams> AddTeamsAsync(CTFTeams teams)
    {
        try
        {
            dbContext.CTFTeams.Add(teams);
            await dbContext.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }
        
        return teams;
    }
    
    public async Task<CTFTeams> UpdateTeamsAsync(CTFTeams teams)
    {
        try
        {
            var TeamsExist = dbContext.CTFTeams.FirstOrDefault(l => l.Id == teams.Id);
            if (TeamsExist != null)
            {
                dbContext.Update(teams);
                await dbContext.SaveChangesAsync();
            }
        }
        catch (Exception)
        {
            throw;
        }
        
        return teams;
    }
    
    public async Task DeleteTeamsAsync(CTFTeams teams)
    {
        try
        {
            dbContext.CTFTeams.Remove(teams);
            await dbContext.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }

}