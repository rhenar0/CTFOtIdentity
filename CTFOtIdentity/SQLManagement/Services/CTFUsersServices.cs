using CTFOtIdentity.SQLManagement.Context;
using CTFOtIdentity.SQLManagement.Definitions;
using Microsoft.EntityFrameworkCore;

namespace CTFOtIdentity.SQLManagement.Services;

public interface ICTFUsersServices
{
    Task<List<CTFUsers>> GetUsersAsync();
    Task<CTFUsers> AddUsersAsync(CTFUsers users);
    Task<CTFUsers> UpdateUsersAsync(CTFUsers users);
    Task DeleteUsersAsync(CTFUsers users);
    CTFUsers GetUserByMail(string mail);
}

public class CTFUsersServices : ICTFUsersServices
{
    private CTFContext dbContext;
    
    public CTFUsersServices(CTFContext dbContext)
    {
        this.dbContext = dbContext;
    }
    
    public async Task<List<CTFUsers>> GetUsersAsync()
    {
        return await dbContext.CTFUsers.ToListAsync();
    }
    
    public async Task<CTFUsers> AddUsersAsync(CTFUsers users)
    {
        try
        {
            dbContext.CTFUsers.Add(users);
            await dbContext.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }
        
        return users;
    }
    
    public async Task<CTFUsers> UpdateUsersAsync(CTFUsers users)
    {
        try
        {
            var UsersExist = dbContext.CTFUsers.FirstOrDefault(l => l.Id == users.Id);
            if (UsersExist != null)
            {
                dbContext.Update(users);
                await dbContext.SaveChangesAsync();
            }
        }
        catch (Exception)
        {
            throw;
        }
        
        return users;
    }
    
    public async Task DeleteUsersAsync(CTFUsers users)
    {
        try
        {
            dbContext.CTFUsers.Remove(users);
            await dbContext.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public CTFUsers GetUserByMail(string mail)
    {
        var Bouh = dbContext.CTFUsers.Where(l => l.Mail == mail).FirstOrDefault();
        return Bouh;
    }
    
}