using VW_CarStock_Classes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace VW_CarStock_Classes
{
    public class CarStockDataAccess : ICarStockDataAccess
    {
        /* DB connection string to be passed in when instatiating this class */
        private readonly string connectionString;

        public CarStockDataAccess()
        {
            connectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;


            /* Populate our DB with data if we've got nothing
             * Note that inside our sp we are checking if the DB has records first... */
           /* using (SqlConnection con = new SqlConnection(connectionString))
            {
                var cmd = new SqlCommand("LoadData_Initial", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error LoadData_Initial: " + ex.Message);
                    throw ex;
                }
            }*/
        }

        /* Return a list of CarStock objects */
        public IList<Car> GetCarStock()
        {
            List<Car> carStock_List = new List<Car>();

            using (SqlConnection con = new SqlConnection(connectionString)) 
            {
                SqlCommand cmd = new SqlCommand("FetchAllCarStock", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Car car = new Car();
                    /*{
                    Id = Convert.ToInt32(rdr["Id"]),
                    Name = rdr["Name"].ToString(),
                    Position = rdr["Position"].ToString(),
                    Office = rdr["Office"].ToString(),
                    Age = Convert.ToInt32(rdr["Age"]),
                    Salary = Convert.ToInt32(rdr["Salary"])*/

                    carStock_List.Add(car);
                };
                 
                return (carStock_List);
            }
        }


        /* Return a single CarStock object */
        public Car GetCarStockById(int id)
        {
            Car car = new Car();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("FetchCarStockById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@car_stock_id", id);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    /* TO-DO get descriptions */
                    car.CarId = Convert.ToInt32(rdr["car_id"]);
                    car.CarTrimLevel = rdr["car_trim_level"].ToString();
                    car.CarMake = rdr["car_make"].ToString();
                    car.CarEngine = rdr["car_engine_description"].ToString();
                    car.CarModel = rdr["car_model_description"].ToString();
                    //car.Price = rdr["car_model_description"].ToFloat();
                    car.NumInStock = Convert.ToInt32(rdr["num_in_stock"]);


                };
            }

            return car;
        }

        public void InsertNewCar(Car car)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                var cmd = new SqlCommand("InsertNewCar", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@carMakeId", car.CarMake);
                cmd.Parameters.AddWithValue("@carModelId", car.CarModel);
                cmd.Parameters.AddWithValue("@carTrimLevelId", car.CarTrimLevel);
                cmd.Parameters.AddWithValue("@carengineTypeId", car.CarEngine);
                cmd.Parameters.AddWithValue("@price", car.Price);
                //cmd.Parameters.AddWithValue("@numStock", car.NumInStock);

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error Updating CarStock: " + ex.Message);
                    throw;
                }

                /* TO-DO: Add car stock level */

            }
        }
    

        public void UpdateCarStock(Car car)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                var cmd = new SqlCommand("UpdateCarStock", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@car_id", car.CarId);
                cmd.Parameters.AddWithValue("@numStock", car.NumInStock);

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error Updating CarStock: " + ex.Message);
                    throw;
                }
                
            }
        }

        public void DeleteCar(Car car)
        {
            if (car == null) 
                return;

            if (car.NumInStock != 0)
                throw new InvalidOperationException("Cannot delete a car for which there is still stock");

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                var cmd = new SqlCommand("DeleteCarStock", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@car_id", car.CarId);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error Deleting Car: " + ex.Message);
                    throw;
                }

            }
        }
    }
    
}
