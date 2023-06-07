using Clase6.Models;

namespace Clase6.Services;

public interface IRestaurantService
{
    void Create(Restaurant obj);
    List<Restaurant> GetAll();
    void Update(Restaurant obj);
    void Delete(Restaurant obj);
    Restaurant? GetById(int id);
}