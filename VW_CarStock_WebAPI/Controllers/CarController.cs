using Microsoft.AspNetCore.Mvc;
using VW_CarStock_Classes;
using System;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VW_CarStock_WebAPI.Controllers
{

    [ApiController]
    public class CarController : ControllerBase
    {
     
        // POST api/<ValuesController>
        [Route("api/createcar")]
        [HttpPost]
        public void CreateCar([FromBody] Car car)
        {

            CarStockDataAccess csda = new CarStockDataAccess();

            Console.WriteLine("Heeeeeyyy");
            Console.WriteLine(car.CarModel);

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
            CarStockDataAccess csda = new CarStockDataAccess();

            try
            {
                /* TO-DO */
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
            CarStockDataAccess csda = new CarStockDataAccess();

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
        //[HttpDelete("{id}")]
        [HttpPost]
        public void DeleteCar(Car car)
        {
            CarStockDataAccess csda = new CarStockDataAccess();

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
