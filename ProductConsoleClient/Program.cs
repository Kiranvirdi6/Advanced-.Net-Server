using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using ProductDataModel;

namespace ProductConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hit a key to get data from server");
            Console.ReadKey();

            HttpClient hc =new HttpClient();

            hc.BaseAddress = new Uri("http://localhost:50000");

            hc.DefaultRequestHeaders.Accept
                .Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );

            HttpResponseMessage hrm = hc.GetAsync("api/products").Result;

            if (hrm.IsSuccessStatusCode)
            {
                List<Product> products=
                hrm.Content.ReadAsAsync<List<Product>>().Result;

                foreach (Product p in products)
                {
                    Console.WriteLine($"{p.Id} - {p.Name} {p.Price}");
                }
            }
            else
            {
                Console.WriteLine("Error Fetching data from server");
            }
            Console.ReadKey();
        }
    }
}
