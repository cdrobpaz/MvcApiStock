using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MvcApiStock.Models
{
    public class Stock
    {
        public int Id { get; set; }
        public string Producto { get; set; }
        public string Tipo { get; set; }
        public string Marca { get; set; }
        public int Unidades { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }
    }
}
