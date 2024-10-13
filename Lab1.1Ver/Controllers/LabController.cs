using Microsoft.AspNetCore.Mvc;
using Lab1._1Ver.Models;
using System.Text.RegularExpressions;

namespace Lab1._1Ver.Controllers
{
    public class LabController : Controller
    {
        public IActionResult Index()
        {
            return View(new SeriesSumModel());
        }

        [HttpPost]
        public IActionResult Calculate(SeriesSumModel model)
        {
            if (!Regex.IsMatch(model.X.ToString(), @"^-?\d+(\.\d+)?$"))
            {
                ModelState.AddModelError("X", "Значение X должно быть числом.");
            }
            else if (model.X <= -2 || model.X >= 2)
            {
                ModelState.AddModelError("X", "Значение X должно быть строго больше -2 и меньше 2.");
            }

            if (!Regex.IsMatch(model.Epsilon.ToString(), @"^-?\d+(\.\d+)?$"))
            {
                ModelState.AddModelError("Epsilon", "Точность ε должна быть числом.");
            }
            else if (model.Epsilon <= 0.000001)
            {
                ModelState.AddModelError("Epsilon", "Точность ε должна быть больше 0.000001.");
            }

            if (ModelState.IsValid)
            {
                double totalSum = 0;
                int n = 1;
                double currentTerm = Math.Pow(model.X, 4 * n) / Math.Pow(16, n);

                model.TermsUsedValues = new List<double>();

                while (currentTerm > model.Epsilon)
                {
                    model.TermsUsedValues.Add(currentTerm);
                    totalSum += currentTerm;
                    n++;
                    currentTerm = Math.Pow(model.X, 4 * n) / Math.Pow(16, n);
                }

                model.Result = totalSum;
                model.TermsUsed = n - 1;
            }

            return View("Index", model);
        }
    }
}
