using FrontEnd_UTI_Statistics.Managers;
using FrontEnd_UTI_Statistics.Models.Estadisticas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FrontEnd_UTI_Statistics.Controllers
{
    [Authorize]
    public class GraficosController : Controller
    {
        public IActionResult Index()
        {
           
            
            estadisticasModel miObjeto = RegistroManager.estadisticas();
            string jsonString = JsonConvert.SerializeObject(miObjeto);
            ViewBag.MiObjetoJson = jsonString;

            return View(miObjeto);
        }
    }
}
