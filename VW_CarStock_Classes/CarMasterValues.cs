using System;
using System.Collections.Generic;
using System.Text;
using VW_CarStock_Classes.Models;

namespace VW_CarStock_Classes
{
    public static class CarMasterValues
    {

        public static Dictionary<int, string> allowedMakes;
        public static Dictionary<int, string> allowedModels;
        public static Dictionary<int, string> allowedTrimLevels;
        public static Dictionary<int, string> allowedFeatures;
        public static Dictionary<int, string> allowedEngineTypes;

        static CarMasterValues()
        {
            CarStockDataAccess csda = new CarStockDataAccess();
            allowedMakes = new Dictionary<int, string>();
            foreach(KeyValuePair<int, string> item in csda.CarMakeList)
                allowedMakes.Add(item.Key, item.Value);

            allowedModels = new Dictionary<int, string>();
            foreach (KeyValuePair<int, string> item in csda.CarModelList)
                allowedModels.Add(item.Key, item.Value);

            allowedTrimLevels = new Dictionary<int, string>();
            foreach (KeyValuePair<int, string> item in csda.CarTrimLevelList)
                allowedTrimLevels.Add(item.Key, item.Value);

            allowedFeatures = new Dictionary<int, string>();
            foreach (KeyValuePair<int, string> item in csda.FeatureList)
                allowedFeatures.Add(item.Key, item.Value);

            allowedEngineTypes = new Dictionary<int, string>(); 
            foreach (KeyValuePair<int, string> item in csda.CarEngineList)
                allowedEngineTypes.Add(item.Key, item.Value);

        }
    }
}
