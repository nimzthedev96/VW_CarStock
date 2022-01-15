using VW_CarStock_Classes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using VW_CarStock_Classes.Models;

namespace VW_CarStock_Classes
{
    public class CarStockDataAccess : ICarStockDataAccess
    {
        /* DB connection string to be passed in when instatiating this class */
        private string connectionString;
        private KeyValuePair<int, string> val;

        public List<KeyValuePair<int, string>> CarModelList;
        public List<KeyValuePair<int, string>> CarMakeList;
        public List<KeyValuePair<int, string>> CarTrimLevelList;
        public List<KeyValuePair<int, string>> FeatureList;
        public List<CarEngineType> CarEngineList;

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
            CarModelList = new List<KeyValuePair<int, string>>();
            CarMakeList =  new List<KeyValuePair<int, string>>();
            CarTrimLevelList = new List<KeyValuePair<int, string>>();
            FeatureList =  new List<KeyValuePair<int, string>>();
           // CarEngineList = initializeListData("Model", "car_model_id", "car_model_description", CarModelList);

            CarMakeList = initializeListData("Make", "car_make_id", "car_make_description", CarMakeList);
            CarTrimLevelList = initializeListData("TrimLevel", "car_trim_level_id", "car_trim_description", CarTrimLevelList);
            FeatureList = initializeListData("FeatureList", "car_feature_id", "feature_description", FeatureList);
            CarEngineList = initializeEngineTypeListData();

            Console.WriteLine("CarModelList count= " + CarModelList.Count);
        }

        private List<KeyValuePair<int, string>> initializeListData(string listType, string fieldNameId, string fieldNameDesc, List<KeyValuePair<int, string>> list)
        {
           // List<KeyValuePair<int, string>> list = new List<KeyValuePair<int, string>> ();
           
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("InitializeList", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@listtype", listType);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    val = new KeyValuePair<int, string>(Convert.ToInt32(rdr[fieldNameId]), 
                                                        rdr["description"].ToString());
                    list.Add(val);
                };
            }

            return list;
        }

        private List<CarEngineType>  initializeEngineTypeListData()
        {
            List<CarEngineType> list = new List<CarEngineType> ();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("InitializeList", con);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@listtype", "EngineType");
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    CarEngineType engType = new CarEngineType();
                    engType.EngineId = Convert.ToInt32(rdr["engine_type_description"]);
                    engType.EnginePower = Convert.ToDecimal(rdr["engine_type_description"]);
                    engType.IsAutomatic = (bool)rdr["is_automatic"];
                    engType.EngineDescription = rdr["engine_type_description"].ToString();
                    list.Add(engType);
                };
            }

            return list;
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
                    car.CarId = Convert.ToInt32(rdr["car_id"]);
                    car.CarTrimLevel = rdr["car_trim_level"].ToString();
                    car.CarMake = rdr["car_make"].ToString();
                    car.CarEngine = rdr["car_engine_description"].ToString();
                    car.CarModel = rdr["car_model_description"].ToString();
                    car.Price = (float)rdr["price"];
                    car.NumInStock = Convert.ToInt32(rdr["num_in_stock"]);
                    car.setEngineTypeDetails(Convert.ToInt32(rdr["car_engine_type_id"]), 
                                             rdr["engine_description"].ToString(),
                                             (bool)rdr["is_automatic"],
                                             Convert.ToDecimal(rdr["engine_power"]));

                    car.Features = new List<string>();
                    SqlCommand cmd2 = new SqlCommand("FetchCarFeaturesByCarId", con);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.AddWithValue("@car_id", car.CarId);
                    con.Open();
                    SqlDataReader rdr2 = cmd2.ExecuteReader();
                    while (rdr2.Read())
                    {
                        car.Features.Add(rdr2["description"].ToString());
                    };

                    carStock_List.Add(car);

                }
                return (carStock_List);
            }
        }


        /* Return a single CarStock object */
        public Car GetCarStockById(int id)
        {
            Car car = new Car();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("FetchCarStockByCarId", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@car_id", id);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    car.CarId = Convert.ToInt32(rdr["car_id"]);
                    car.CarTrimLevel = rdr["car_trim_level"].ToString();
                    car.CarMake = rdr["car_make_description"].ToString();
                    car.CarEngine = rdr["engine_description"].ToString();
                    car.CarModel = rdr["car_model_description"].ToString();
                    car.Price = (float)rdr["car_model_description"];
                    car.NumInStock = Convert.ToInt32(rdr["num_in_stock"]);
                };
                con.Close();
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
    

        public void UpdateCar(Car car)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                var cmd = new SqlCommand("UpdateCarStock", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@car_id", car.CarId);
                cmd.Parameters.AddWithValue("@carMakeId", car.CarMake);
                cmd.Parameters.AddWithValue("@carModelId", car.CarModel);
                cmd.Parameters.AddWithValue("@carTrimLevelId", car.CarTrimLevel);
                cmd.Parameters.AddWithValue("@carengineTypeId", car.CarEngine);
                cmd.Parameters.AddWithValue("@price", car.Price);
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

        public void UpdateCarStock(Car car)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                var cmd = new SqlCommand("UpdateCar", con);
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
