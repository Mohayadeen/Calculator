using CalculatorApi.Models;
using CoreCalculator.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CoreCalculator.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public async Task<string> Status()
        {
            return "Success - Calculator";
        }

        [HttpGet]
        public async Task<IActionResult> Index(Operation model)
        {
            if(model!=null && model.NumberA>0)
            {              
                string jsoninput = Newtonsoft.Json.JsonConvert.SerializeObject(model);
                using (var stringContent = new StringContent(jsoninput, System.Text.Encoding.UTF8, "application/json"))
                using (var client = new HttpClient())
                {
                    try
                    {
                        string url = Environment.GetEnvironmentVariable("Url"); //"http://localhost:5246/abdul/getdata"
                        var response = await client.PostAsync(url, stringContent);
                        var result1 = await response.Content.ReadAsStringAsync();
                        CalculatorApi.Models.Operation obj = Newtonsoft.Json.JsonConvert.DeserializeObject<CalculatorApi.Models.Operation>(result1);
                        model = obj;
                        Console.WriteLine(result1);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            return View(model);
        }
    }
}
