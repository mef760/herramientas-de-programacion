using Clase6.Data;
using Clase6.Models;
using Microsoft.EntityFrameworkCore;

namespace Clase6.Services;

public class MenuService : IMenuService
{
    private readonly MenuContext _context;

    public MenuService(MenuContext context)
    {
        _context = context;
    }

    public void Create(Menu obj)
    {
        _context.Add(obj);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var obj = GetById(id);
        
        if (obj != null){
            _context.Remove(obj);
            _context.SaveChanges();
        }
    }
    public List<Menu> GetAll()
    {
        var query = GetQuery();
        return query.ToList();
    }

    public List<Menu> GetAll(string filter)
    {
        var query = GetQuery();

        if (!string.IsNullOrEmpty(filter))
        {
            query = query.Where(x => x.Name.Contains(filter));
        }

        return query.ToList();
    }

    public Menu? GetById(int id)
    {

        var menu = GetQuery()
                .Include(x=> x.Restaurants)
                .FirstOrDefault(m => m.Id == id);

        return menu;
    }

    public void Update(Menu obj)
    {
        _context.Update(obj);
        _context.SaveChanges();
    }

    private IQueryable<Menu> GetQuery()
    {
        return from menu in _context.Menu select menu;
    }
}