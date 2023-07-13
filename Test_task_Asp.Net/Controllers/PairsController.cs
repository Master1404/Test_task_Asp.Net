using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Test_task_Asp.Net.Core;
using Test_task_Asp.Net.Models;

namespace Test_task_Asp.Net.Controllers
{
    public class PairsController : Controller
    {
        private readonly IPairsProvider _pairsProvider;

        public PairsController(IPairsProvider pairsProvider)
        {
            _pairsProvider = pairsProvider;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            int pageSize = 20;

            uint pairsCount = await _pairsProvider.CountAsync();
            IEnumerable<string> pairs = await _pairsProvider.GetPairsAsync(page);

            int totalPages = (int)Math.Ceiling((double)pairsCount / pageSize);

            var model = new PairsViewModel
            {
                TotalPairs = pairsCount,
                Pairs = pairs,
                CurrentPage = page,
                TotalPages = totalPages
            };

            return View(model);
        }
    }
}