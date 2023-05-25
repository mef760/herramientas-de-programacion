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
    public class MenuController : Controller
    {
        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        // GET: Menu
        public IActionResult Index(string nameFilter)
        {
            var model = new MenuViewModel();
            model.Menus = _menuService.GetAll(nameFilter);
            return View(model);
        }

        // GET: Menu/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = _menuService.GetById(id.Value);
            if (menu == null)
            {
                return NotFound();
            }

            var viewModel = new MenuDetailViewModel();
            viewModel.Name = menu.Name;
            viewModel.Type = menu.Type.ToString();
            viewModel.Calories = menu.Calories;
            viewModel.IsVegetarian = menu.IsVegetarian;
            viewModel.Restaurants = menu.Restaurants != null ? menu.Restaurants : new List<Restaurant>();

            return View(viewModel);
        }

        // GET: Menu/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Menu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Price,Type,IsVegetarian,Calories")] Menu menu)
        {
            ModelState.Remove("Restaurants");
            if (ModelState.IsValid)
            {
                _menuService.Create(menu);
                return RedirectToAction(nameof(Index));
            }
            return View(menu);
        }

        // GET: Menu/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = _menuService.GetById(id.Value);
            if (menu == null)
            {
                return NotFound();
            }
            return View(menu);
        }

        // POST: Menu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Price,Type,IsVegetarian,Calories")] Menu menu)
        {
            if (id != menu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _menuService.Update(menu);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MenuExists(menu.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(menu);
        }

        // GET: Menu/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = _menuService.GetById(id.Value);
            if (menu == null)
            {
                return NotFound();
            }

            return View(menu);
        }

        // POST: Menu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _menuService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool MenuExists(int id)
        {
          return _menuService.GetById(id) != null;
        }
    }
}
