using Microsoft.AspNetCore.Mvc;
using MvcApiStock.Models;
using MvcApiStock.Services;

namespace MvcApiStock.Controllers
{
    public class StockController : Controller
    {
        private ServiceStock service;
        public StockController(ServiceStock service)
        {
            this.service = service;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateStock()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateStock(Stock s)
        {
            await this.service.CreateStock(s.Id, s.Producto, s.Tipo, s.Marca, s.Unidades, s.PrecioCompra, s.PrecioVenta);
            return RedirectToAction("Index");
        }
        public IActionResult UpdateStockUnidades()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateStockUnidades(int id, int unidades)
        {
            await this.service.UpdateStockUnidadesAsync(id, unidades);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteStock()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DeleteStock(int id)
        {
            await this.service.DeleteStockAsync(id);
            return RedirectToAction("Index");
        }
    }
}
