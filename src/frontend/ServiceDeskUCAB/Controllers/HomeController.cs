﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ModuloPlantillasNotificaciones.Models;
using ModuloPlantillasNotificaciones.Servicios;
using System.Diagnostics;

namespace ModuloPlantillasNotificaciones.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IServicioPlantillaNotificacion_API _servicioApi;

        public HomeController(ILogger<HomeController> logger, IServicioPlantillaNotificacion_API servicioApi)
        {
            _logger = logger;
            _servicioApi = servicioApi;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}