using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using VW_CarStock_Classes;


namespace VW_CarStock_WebApp.Pages
{
    public class ViewCarStock : PageModel
    {
        private readonly ILogger<ViewCarStock> _logger;
        public IEnumerable<Car> Cars { get; set; }

        public ViewCarStock(ILogger<ViewCarStock> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
 
            CarStockDataAccess csda = new CarStockDataAccess();
            Cars = csda.GetCarStock();
        }
    }
}
