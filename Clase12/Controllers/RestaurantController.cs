using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Clase6.Data;
using Clase6.Models;
using Clase6.ViewModels;
using Clase6.Services;

namespace Clase6.Controllers
{
    public class RestaurantController : Controller
    {  
        private IRestaurantService _restaurantService;  
        private IMenuService _menuService;

        public RestaurantController(
            IRestaurantService restaurantService,
            IMenuService menuService)
        {
            _restaurantService = restaurantService;
            _menuService = menuService;
        }

        // GET: Restaurant
        public IActionResult Index()
        {
            var list = _restaurantService.GetAll();
            return View(list);
        }

        // GET: Restaurant/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurant = _restaurantService.GetById(id.Value);
            if (restaurant == null)
            {
                return NotFound();
            }

            return View(restaurant);
        }

        // GET: Restaurant/Create
        public IActionResult Create()
        {
            var menuList = _menuService.GetAll();
            ViewData["Menus"] = new SelectList(menuList, "Id", "Name");
            return View();
        }

        // POST: Restaurant/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Address,Mail,Phone,MenuIds")] RestaurantCreateViewModel restaurantView)
        {
            if (ModelState.IsValid)
            {
                var menus = _menuService.GetAll().Where(x=> restaurantView.MenuIds.Contains(x.Id)).ToList();

                var restaurant = new Restaurant{
                    Name = restaurantView.Name,
                    Address = restaurantView.Address,
                    Phone = restaurantView.Phone,
                    Mail = restaurantView.Mail,
                    Menus = menus
                }; 
                _restaurantService.Create(restaurant);

                return RedirectToAction(nameof(Index));
            }

            // llenar view model con errores
            
            return View(restaurantView);
        }

        // GET: Restaurant/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurant = _restaurantService.GetById(id.Value);
            if (restaurant == null)
            {
                return NotFound();
            }
            
            return View(restaurant);
        }

        // POST: Restaurant/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Address,Mail,Phone,MenuId")] Restaurant restaurant)
        {
            if (id != restaurant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _restaurantService.Update(restaurant);
                return RedirectToAction(nameof(Index));
            }
            
            return View(restaurant);
        }

        // GET: Restaurant/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurant = _restaurantService.GetById(id.Value);
            if (restaurant == null)
            {
                return NotFound();
            }

            return View(restaurant);
        }

        // POST: Restaurant/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var restaurant = _restaurantService.GetById(id);
            if (restaurant != null)
            {
                _restaurantService.Delete(restaurant);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool RestaurantExists(int id)
        {
          return _restaurantService.GetById(id) != null;
        }
    }
}
