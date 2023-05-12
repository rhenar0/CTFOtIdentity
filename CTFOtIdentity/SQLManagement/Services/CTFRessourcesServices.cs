using CTFOtIdentity.SQLManagement.Context;
using CTFOtIdentity.SQLManagement.Definitions;
using Microsoft.EntityFrameworkCore;

namespace CTFOtIdentity.SQLManagement.Services;

public interface ICTFRessourcesServices
{
    Task<List<CTFRessources>> GetRessourcesAsync();
    Task<CTFRessources> AddRessourcesAsync(CTFRessources ressources);
    Task<CTFRessources> UpdateRessourcesAsync(CTFRessources ressources);
    Task DeleteRessourcesAsync(CTFRessources ressources);

    List<CTFRessources> GetRessourcesByEtapesAndTypeAsync(int id, string type);
}

public class CTFRessourcesServices : ICTFRessourcesServices
{
    private CTFContext dbContext;
    
    public CTFRessourcesServices(CTFContext dbContext)
    {
        this.dbContext = dbContext;
    }
    
    public async Task<List<CTFRessources>> GetRessourcesAsync()
    {
        return await dbContext.CTFRessources.ToListAsync();
    }
    
    public async Task<CTFRessources> AddRessourcesAsync(CTFRessources ressources)
    {
        try
        {
            dbContext.CTFRessources.Add(ressources);
            await dbContext.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }
        
        return ressources;
    }
    
    public async Task<CTFRessources> UpdateRessourcesAsync(CTFRessources ressources)
    {
        try
        {
            var RessourcesExist = dbContext.CTFRessources.FirstOrDefault(l => l.Id == ressources.Id);
            if (RessourcesExist != null)
            {
                dbContext.Update(ressources);
                await dbContext.SaveChangesAsync();
            }
        }
        catch (Exception)
        {
            throw;
        }
        
        return ressources;
    }
    
    public async Task DeleteRessourcesAsync(CTFRessources ressources)
    {
        try
        {
            dbContext.CTFRessources.Remove(ressources);
            await dbContext.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }
    
    public async Task GetRessourcesByEtapesAsync(int id)
    {
        try
        {
            var ressources = await dbContext.CTFRessources.Where(l => l.IdAssociatedEta == id).ToListAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }
    
    public List<CTFRessources> GetRessourcesByEtapesAndTypeAsync(int id, string type)
    {
        try
        {
             return dbContext.CTFRessources.Where(l => l.IdAssociatedEta == id && l.Type == type).ToList();
        }
        catch (Exception)
        {
            throw;
        }
    }
    
}