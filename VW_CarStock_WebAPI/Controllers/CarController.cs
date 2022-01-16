using Microsoft.AspNetCore.Mvc;
using VW_CarStock_Classes;
using VW_CarStock_WebAPI;
using System;
using System.Configuration;
using Microsoft.Web;


namespace VW_CarStock_WebAPI.Controllers
{

    [ApiController]
    public class CarController : ControllerBase
    {
        private CarStockDataAccess csda = new CarStockDataAccess(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);

        // POST api/<ValuesController>
        [Route("api/createcar")]
        [HttpPost]
        public ActionResult CreateCar([FromBody] Car car)
        {
            System.Diagnostics.Debug.Write("inside create car " + car.CarEngineId.ToString());

            try
            {
                csda.InsertNewCar(car);
               
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                return new JsonResult("{ success = false, response = " + e.Message + " }");

            }

            return new JsonResult("{ success = true, response = 'Success:New car created' }");
        }

        [Route("api/updateCar")]
        [HttpPost]
        public ActionResult UpdateCar([FromBody] Car car)
        {
            System.Diagnostics.Debug.WriteLine("!!!---- car.Features.Count" + car.Features.Count);

            try
            {
                csda.UpdateCar(car);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                return new JsonResult("{ success = false, response = " + e.Message + " }");
            }

            return new JsonResult("{ success = true, response = 'Success' }");
        }

        [Route("api/updatecarstock")]
        [HttpPost]
        public ActionResult UpdateCarStock(Car car)
        {
            Console.WriteLine("carId " + car.CarId);
            Console.WriteLine("numStock " + car.NumInStock);

            try
            {
                csda.UpdateCarStock(car);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                return new JsonResult("{ success = false, responseText = " + e.Message + " }");
            }

            return new JsonResult("{ success = true, responseText = 'Success' }");
        }


        // DELETE api/<ValuesController>/5
        [Route("api/deletecar")]
        [HttpPost]
        public ActionResult DeleteCar(Car car)
        {
            try
            {
                csda.DeleteCar(car);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                return new JsonResult("{ success = false, response = " + e.Message + " }");
            }

            return new JsonResult("{ success = true, response = 'Success' }");
        }
    }
}
