using Clase6.Models;

namespace Clase6.Services;

public interface IMenuService
{
    void Create(Menu obj);
    List<Menu> GetAll(string filter);
    List<Menu> GetAll();
    void Update(Menu obj);
    void Delete(int id);
    Menu? GetById(int id);

}