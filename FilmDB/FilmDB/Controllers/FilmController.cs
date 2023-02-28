using FilmDB.Logic;
using FilmDB.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Reflection;

namespace FilmDB.Controllers
{
    public class FilmController : Controller
    {
        FilmManager filmManager = new FilmManager();    
        /*public IActionResult Index()
        {
            var random = new Random();
            var film = new FilmModel()
            {
                Name = "Niesmiertelni",
                Year = 1999
            };
            filmManager.AddFilm(film);
           
            return View();
        }*/

        [HttpGet]
        public IActionResult Add()
        {
            return View();  
        }
        [HttpPost]
        public IActionResult Add(FilmModel filmModel)
        {
            filmManager.AddFilm(filmModel);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Index()
        {
            var filmy = filmManager.GetFilms();
            return View(filmy);
        }
       
        [HttpGet]
        public IActionResult Remove(int id)
        {
            var film = filmManager.GetFilm(id);
            return View(film);
        }
       
        [HttpPost]
        public IActionResult RemoveConfirm(int id)
        {
            filmManager.RemoveFilm(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var film = filmManager.GetFilm(id);
            return View(film);
        }
        
        [HttpPost]
        public IActionResult Edit(FilmModel film)
        {
            filmManager.UpdateFilm(film);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Wzorce(int id)
        {
            return View("Wzorce");
        }
        [HttpGet]
        public IActionResult Oswiadczenie(int id)
        {
            return View("Oswiadczenie");
        }
    }

}
