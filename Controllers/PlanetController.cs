using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    [Route("he-mat-troi/[action]")]
    public class PlanetController : Controller
    {
        private readonly PlanetService _planetService;
        private readonly ILogger<PlanetController> _logger;

        public PlanetController(PlanetService planetService, ILogger<PlanetController> logger)
        {
            _planetService = planetService;
            _logger = logger;
        }
        [BindProperty(SupportsGet = true, Name = "action")]
        public string Name {get; set;}

        public IActionResult Index()
        {
            return View();
        }
        [Route("sao-thuy")]
        public IActionResult Mercury() {
            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Details", planet);
        }
        public IActionResult Venus() {
            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Details", planet);
        }
        public IActionResult Earth() {
            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Details", planet);
        }
        public IActionResult Mars() {
            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Details", planet);
        }
        public IActionResult Jupiter() {
            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Details", planet);
        }
        public IActionResult Saturn() {
            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Details", planet);
        }
        public IActionResult Uranus() {
            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Details", planet);
        }
        // [Route("Sao")]
        // [Route("Sao/[action]")]
        // [Route("Sao/[controller]/[action]")]
        [Route("[controller]-[action].html")]
        public IActionResult Neptune() {
            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Details", planet);
        }
        [Route("hanhtinh/{id:int}")]
        public IActionResult PlanetInfo(int id) {
            var planet = _planetService.Where(p => p.Id == id).FirstOrDefault();
            return View("Details", planet);
        }

    }
}