using System;
using System.Collections.Generic;
using System.Text;

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

        public int CarId { get => carId; set => carId = value; }
        public string CarMake { get => carMake; set => carMake = value; }
        public string CarModel { get => carModel; set => carModel = value; }
        public string CarEngine { get => carEngine; set => carEngine = value; }
        public string CarTrimLevel { get => carTrimLevel; set => carTrimLevel = value; }
        public float Price { get => price; set => price = value; }
        public int NumInStock { get => numInStock; set => numInStock = value; }


    }
}
