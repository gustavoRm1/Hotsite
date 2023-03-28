using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Hotsite.Models;


namespace Hotsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private bool ex;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Interesse cad)
        {
             try{
                DatabaseService dbs = new DatabaseService();
                dbs.CadastraInteresse(cad);
                ViewBag.Message = "Nós recebemos sua mensagem!";
                return View("Index",cad);
                
            } catch (Exception ex){
                Console.WriteLine(ex);
                return View("Index");
            }


               
                



        }

    }
}
