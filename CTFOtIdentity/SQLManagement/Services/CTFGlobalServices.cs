using CTFOtIdentity.SQLManagement.Context;
using CTFOtIdentity.SQLManagement.Definitions;
using Microsoft.EntityFrameworkCore;

namespace CTFOtIdentity.SQLManagement.Services;

public interface ICTFGlobalServices
{
    Task<List<CTFGlobal>> GetGlobalAsync();
    Task<CTFGlobal> AddGlobalAsync(CTFGlobal global);
    Task<CTFGlobal> UpdateGlobalAsync(CTFGlobal global);
    Task DeleteGlobalAsync(CTFGlobal global);
}


public class CTFGlobalServices : ICTFGlobalServices
{
    
    private CTFContext dbContext;
    
    public CTFGlobalServices(CTFContext dbContext)
    {
        this.dbContext = dbContext;
    }
    
    public async Task<List<CTFGlobal>> GetGlobalAsync()
    {
        return await dbContext.CTFGlobal.ToListAsync();
    }
    
    public async Task<CTFGlobal> AddGlobalAsync(CTFGlobal global)
    {
        try
        {
            dbContext.CTFGlobal.Add(global);
            await dbContext.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }
        
        return global;
    }
    
public async Task<CTFGlobal> UpdateGlobalAsync(CTFGlobal global)
    {
        try
        {
            var GlobalExist = dbContext.CTFGlobal.FirstOrDefault(l => l.Id == global.Id);
            if (GlobalExist != null)
            {
                dbContext.Update(global);
                await dbContext.SaveChangesAsync();
            }
        }
        catch (Exception)
        {
            throw;
        }
        
        return global;
    }

    public async Task DeleteGlobalAsync(CTFGlobal global)
    {
        try
        {
            dbContext.CTFGlobal.Remove(global);
            await dbContext.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }

}