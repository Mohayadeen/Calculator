using CoreCalculator.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreCalculator.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Operation model)
        {
            if (model.OperationType == OperationType.Addition)
                model.Result = model.NumberA + model.NumberB;
            else if (model.OperationType == OperationType.Subtraction)
                model.Result = model.NumberA - model.NumberB;
            else if (model.OperationType == OperationType.Multiplication)
                model.Result = model.NumberA * model.NumberB;
            else model.Result = model.NumberA / model.NumberB;
            
            return View(model);
        }
    }
}
