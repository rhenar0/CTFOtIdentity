using CTFOt.SQLManagement.Context;
using CTFOt.SQLManagement.Definitions;
using Microsoft.EntityFrameworkCore;

namespace CTFOt.SQLManagement.Services;

public interface ICTFChallsServices
{
    Task<List<CTFChalls>> GetChallsAsync();
    Task<CTFChalls> AddChallsAsync(CTFChalls challs);
    Task<CTFChalls> UpdateChallsAsync(CTFChalls challs);
    Task DeleteChallsAsync(CTFChalls challs);
}

public class CTFChallsServices : ICTFChallsServices
{
    private CTFContext dbContext;
    
    public CTFChallsServices(CTFContext dbContext)
    {
        this.dbContext = dbContext;
    }
    
    public async Task<List<CTFChalls>> GetChallsAsync()
    {
        return await dbContext.CTFChalls.ToListAsync();
    }
    
    public async Task<CTFChalls> AddChallsAsync(CTFChalls challs)
    {
        try
        {
            dbContext.CTFChalls.Add(challs);
            await dbContext.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }
        
        return challs;
    }
    
    public async Task<CTFChalls> UpdateChallsAsync(CTFChalls challs)
    {
        try
        {
            var ChallsExist = dbContext.CTFChalls.FirstOrDefault(l => l.Id == challs.Id);
            if (ChallsExist != null)
            {
                dbContext.Update(challs);
                await dbContext.SaveChangesAsync();
            }
        }
        catch (Exception)
        {
            throw;
        }
        
        return challs;
    }
    
    public async Task DeleteChallsAsync(CTFChalls challs)
    {
        try
        {
            dbContext.CTFChalls.Remove(challs);
            await dbContext.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }
}