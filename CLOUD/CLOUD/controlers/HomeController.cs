using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Net.Http;

namespace CLOUD.controlers
{
 [Route("api/[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        [HttpPost]
        public async Task<int> DoSomething(int x)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync($"http://127.0.0.1:5000/do?x={x}");

                    if (response.IsSuccessStatusCode)
                    {
                        Console.Write("Success");
                    }
                    else
                    {
                        Console.Write("Failure");
                    }

                    return int.Parse(await response.Content.ReadAsStringAsync());
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}


