﻿using Microsoft.AspNetCore.Mvc;
using VW_CarStock_Classes;
using VW_CarStock_WebAPI;
using System;
using System.Configuration;

namespace VW_CarStock_WebAPI.Controllers
{

    [ApiController]
    public class CarController : ControllerBase
    {
        private CarStockDataAccess csda = new CarStockDataAccess(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);

        // POST api/<ValuesController>
        [Route("api/createcar")]
        [HttpPost]
        public void CreateCar([FromBody] Car car)
        { 

            try
            {
                csda.InsertNewCar(car);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                //return "Error: " + e.Message;
            }

            //return "Success";

        }

        [Route("api/updateCar")]
        [HttpPost]
        public void UpdateCar([FromBody] Car car)
        {
            try
            {
                csda.UpdateCar(car);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                //return "Error: " + e.Message;
            }

            //return "Success";
        }

        [Route("api/updatecarstock")]
        [HttpPost]
        public void UpdateCarStock(Car car)
        {
            try
            {
                csda.UpdateCarStock(car);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                //return "Error: " + e.Message;
            }

            //return "Success";
        }


        // DELETE api/<ValuesController>/5
        [Route("api/deletecar")]
        [HttpPost]
        public void DeleteCar(Car car)
        {
            try
            {
                csda.DeleteCar(car);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                //return "Error: " + e.Message;
            }

           // return "Success";
        }
    }
}
