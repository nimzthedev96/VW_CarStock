using System;
using System.Collections.Generic;
using System.Text;
using VW_CarStock_Classes.Models;

namespace VW_CarStock_Classes
{
    public class Car : ICar
    {
        private int carId;
        private int numInStock;
        private decimal price;
        private int carTrimLevelId;
        private int carEngineId;
        private int carModelId;
        private int carMakeId;
        private string carTrimLevel;
        private string carEngine;
        private string carModel;
        private string carMake;
        private List<KeyValuePair<int, string>> features;

        private CarEngineType carEngineType;

        public int CarId { get => carId; set => carId = value; }
        public int CarTrimLevelId { get => carTrimLevelId;
            set
            {
                carTrimLevelId = value;
                CarMasterValues.allowedTrimLevels.TryGetValue(value, out carTrimLevel);      
            }
        }
        public int CarEngineId { get => carEngineId; set => carEngineId = value; }
        public int CarModelId { get => carModelId;
            set
            {
                carModelId = value;
                CarMasterValues.allowedModels.TryGetValue(value, out carModel);
            }
        }
        public int CarMakeId { get => carMakeId;
            set
            {
                carMakeId = value;
                CarMasterValues.allowedMakes.TryGetValue(value, out carMake);
            }
        }

        public string CarMake { get => carMake; }
        public string CarModel { get => carModel; }
        public string CarTrimLevel { get => carTrimLevel; }
        public decimal Price { get => price; set => price = value; }
        public int NumInStock { get => numInStock; set => numInStock = value; }
        public List<KeyValuePair <int,string>> Features {
            get => features;
            set
            {
                features = value;
            }
        }
        public CarEngineType CarEngineType {get => carEngineType; 
            set 
            { 

            } 
        }

        public void setEngineTypeDetails(int id, string description, bool isAuto, decimal power)
        {
            carEngineType.EngineId = id;
            carEngineType.EngineDescription = description;
            carEngineType.IsAutomatic = isAuto;
            carEngineType.EnginePower = power;
        }

        public Car()
        {
            carId = -1;
            features = new List<KeyValuePair<int, string>>();
            carEngineType = new CarEngineType();
        }
    }
}
