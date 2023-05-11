using CTFOt.SQLManagement.Context;
using CTFOt.SQLManagement.Definitions;
using Microsoft.EntityFrameworkCore;

namespace CTFOt.SQLManagement.Services;

public interface ICTFCategroiesServices
{
    Task<List<CTFCategories>> GetCategoriesAsync();
    Task<CTFCategories> AddCategoriesAsync(CTFCategories categories);
    Task<CTFCategories> UpdateCategoriesAsync(CTFCategories categories);
    Task DeleteCategoriesAsync(CTFCategories categories);
}

public class CTFCategoriesServices : ICTFCategroiesServices
{
    private CTFContext dbContext;
    
    public CTFCategoriesServices(CTFContext dbContext)
    {
        this.dbContext = dbContext;
    }
    
    public async Task<List<CTFCategories>> GetCategoriesAsync()
    {
        return await dbContext.CTFCategories.ToListAsync();
    }
    
    public async Task<CTFCategories> AddCategoriesAsync(CTFCategories categories)
    {
        try
        {
            dbContext.CTFCategories.Add(categories);
            await dbContext.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }
        
        return categories;
    }
    
    public async Task<CTFCategories> UpdateCategoriesAsync(CTFCategories categories)
    {
        try
        {
            var CategoriesExist = dbContext.CTFCategories.FirstOrDefault(l => l.Id == categories.Id);
            if (CategoriesExist != null)
            {
                dbContext.Update(categories);
                await dbContext.SaveChangesAsync();
            }
        }
        catch (Exception)
        {
            throw;
        }
        
        return categories;
    }
    
    public async Task DeleteCategoriesAsync(CTFCategories categories)
    {
        try
        {
            dbContext.CTFCategories.Remove(categories);
            await dbContext.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }
}