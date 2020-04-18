using System.Threading.Tasks;
using CalculatorApi.Models;
using Microsoft.AspNetCore.Mvc;
namespace CalculatorApi.Controllers
{
    public class AbdulController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]        
        public async Task<Operation> GetData([FromBody]Operation model)
        {
            if (model.OperationType == OperationType.Addition)
                model.Result = model.NumberA + model.NumberB;
            else if (model.OperationType == OperationType.Subtraction)
                model.Result = model.NumberA - model.NumberB;
            else if (model.OperationType == OperationType.Multiplication)
                model.Result = model.NumberA * model.NumberB;
            else model.Result = model.NumberA / model.NumberB;

            return model;
        }

        [HttpGet]
        public async Task<string> Status()
        {
            return "Success - CalculatorApi";
        }
    }
}
