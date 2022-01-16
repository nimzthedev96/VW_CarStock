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

        public Car car;
        public IEnumerable<KeyValuePair<int, string>> CarModelList ;
        public IEnumerable<KeyValuePair<int, string>> CarMakeList;
        public IEnumerable<KeyValuePair<int, string>> CarEngineList;
        public IEnumerable<KeyValuePair<int, string>> CarTrimLeveList;
        public IEnumerable<KeyValuePair<int, string>> FeatureList;

        public ModifyCarStock(ILogger<ModifyCarStock> logger)
        {
            _logger = logger;
        }

        public void OnGet(int carid)
        {
            CarStockDataAccess csda = new CarStockDataAccess();
            if (carid != 0)
                car = csda.GetCarStockById(carid);
            else
                car = new Car();
 
            CarModelList = csda.CarModelList;
            CarMakeList = csda.CarMakeList;
            CarTrimLeveList = csda.CarTrimLevelList;
            FeatureList = csda.FeatureList;
            CarEngineList = csda.CarEngineList;

        }

    }
}
