using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VW_CarStock_Classes;

namespace VW_CarStock_WebApp.Pages
{
    public class ModifyCarStock : PageModel
    {
        private readonly ILogger<ModifyCarStock> _logger;

        public ModifyCarStock(ILogger<ModifyCarStock> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
