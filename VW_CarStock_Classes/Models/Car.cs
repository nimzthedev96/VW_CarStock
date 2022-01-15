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
        private float price;
        private string carTrimLevel;
        private string carEngine;
        private string carModel;
        private string carMake;
        private List<string> features;
        private CarEngineType carEngineType;

        public int CarId { get => carId; set => carId = value; }
        public string CarMake { get => carMake; set => carMake = value; }
        public string CarModel { get => carModel; set => carModel = value; }
        public string CarEngine { get => carEngine; set => carEngine = value; }
        public string CarTrimLevel { get => carTrimLevel; set => carTrimLevel = value; }
        public float Price { get => price; set => price = value; }
        public int NumInStock { get => numInStock; set => numInStock = value; }
        public List<string> Features { get; set; }
        public CarEngineType CarEngineType {get;}

        public void setEngineTypeDetails(int id, string description, bool isAuto, decimal power)
        {
            carEngineType.EngineId = id;
            carEngineType.EngineDescription = description;
            carEngineType.IsAutomatic = isAuto;
            carEngineType.EnginePower = power;
            carEngineType.FullDescription = carEngineType.EnginePower.ToString() + "L "
                                          + carEngineType.EngineDescription + " ";

            if (carEngineType.IsAutomatic)
                carEngineType.FullDescription = carEngineType.FullDescription + " Automatic";
            else 
                carEngineType.FullDescription = carEngineType.FullDescription + " Manual";
        }
    }
}
