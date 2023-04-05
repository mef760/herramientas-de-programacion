using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Clase4.Models;
using Clase4.Services;

namespace Clase4.Controllers;

public class MovieController : Controller
{
    public MovieController()
    {
    }

    public IActionResult Index()
    {   
        var model = new List<Movie>();
        model = MovieService.GetAll();

        return View(model);
    }

    public IActionResult Detail(string id)
    {
        var model = MovieService.Get(id);

        return View(model);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Movie movie){
        if(!ModelState.IsValid){
            return RedirectToAction("Create");
        }

        MovieService.Add(movie);

        return RedirectToAction("Index");
    }
}
