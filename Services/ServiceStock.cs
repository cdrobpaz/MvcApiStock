using MvcApiStock.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace MvcApiStock.Services
{
    public class ServiceStock
    {
        private string UrlApi;
        private string token;
        private MediaTypeWithQualityHeaderValue Header;
        public ServiceStock(string url, string token)
        {
            this.UrlApi = url;
            this.token = token;
            this.Header = new MediaTypeWithQualityHeaderValue("application/json");
        }
        //private async Task<T> CallApiAsync<T>(string request)
        //{
        //    using (HttpClient client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri(this.UrlApi);
        //        client.DefaultRequestHeaders.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(this.Header);
        //        client.DefaultRequestHeaders.Add("Authorization", "bearer " + this.token);
        //        HttpResponseMessage response = await client.GetAsync(request);
        //        if (response.IsSuccessStatusCode)
        //        {
        //            T data = await response.Content.ReadAsAsync<T>();
        //            return data;
        //        }
        //        else
        //        {
        //            return default(T);
        //        }
        //    }
        //}
        //public async Task<List<Stock>> GetStockAsync()
        //{
        //    string request = "/api/stock";
        //    List<Stock> ss = await this.CallApiAsync<List<Stock>>(request);
        //    return ss;
        //}
        //public async Task<Stock> FindStockAsync(int id)
        //{
        //    string request = "api/stoock/" + id;
        //    Stock s = await this.CallApiAsync<Stock>(request);
        //    return s;
        //}
        public async Task CreateStock(int id, string producto, string tipo, string marca, int unidades, decimal precioCompra, decimal precioVenta)
        {
            using(HttpClient client = new HttpClient())
            {
                string request = "/api/stock";
                client.BaseAddress = new Uri(this.UrlApi);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authorization", "bearer " + this.token);
                Stock s = new Stock();
                s.Id = id;
                s.Producto = producto;
                s.Tipo = tipo;
                s.Marca = marca;
                s.Unidades = unidades;
                s.PrecioCompra  = precioCompra;
                s.PrecioVenta = precioVenta;
                string json = JsonConvert.SerializeObject(s);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                await client.PostAsync(request, content);
            }
        }
        public async Task UpdateStockUnidadesAsync(int id, int unidades)
        {
            using(HttpClient client = new HttpClient())
            {
                string request = "api/stock/updatestockunidades/" + id + "/" + unidades;
                client.BaseAddress = new Uri(this.UrlApi);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authorization", "bearer " + this.token);
                StringContent content = new StringContent("", Encoding.UTF8, "application/json");
                await client.PutAsync(request, content);
            }
        }
        public async Task DeleteStockAsync(int id)
        {
            using(HttpClient client = new HttpClient())
            {
                string request = "api/stock/" + id;
                client.BaseAddress = new Uri(this.UrlApi);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authorization", "bearer " + this.token);
                await client.DeleteAsync(request);
            }
        }
    }
}
