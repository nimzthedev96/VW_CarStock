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
        public List<KeyValuePair<int, string>> CarEngineList;

        public CarStockDataAccess()
        {
            connectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            InitializeData();
        }

        public CarStockDataAccess(string cs)
        {
            connectionString = cs;
            InitializeData();
        }

        public void InitializeData()
        {
            /* Populate our DB with data if we've got nothing
             * Note that inside our sp we are checking if the DB has records first... */
            using (SqlConnection con = new SqlConnection(connectionString))
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
            }

            CarModelList = initializeListData("InitializeModelList", "car_model_id", "car_model_description");
            CarMakeList = initializeListData("InitializeMakeList", "car_make_id", "car_make_description");
            CarTrimLevelList = initializeListData("InitializeCarTrimLevelList", "car_trim_level_id", "car_trim_level_description");
            FeatureList = initializeListData("InitializeFeatureList", "car_feature_id", "feature_description");
            CarEngineList = initializeEngineTypeListData();
        }

        private List<KeyValuePair<int, string>> initializeListData(string sp, string fieldNameId, string fieldNameDesc)
        {
            List<KeyValuePair<int, string>> list = new List<KeyValuePair<int, string>> ();
            System.Diagnostics.Debug.WriteLine("initializeListData called " + sp);
            System.Diagnostics.Debug.WriteLine("Connection string"  + connectionString);

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                System.Diagnostics.Debug.WriteLine("inside usinbg con");
                SqlCommand cmd = new SqlCommand(sp, con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
              
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    System.Diagnostics.Debug.WriteLine("Adding to list");

                    val = new KeyValuePair<int, string>(Convert.ToInt32(rdr[fieldNameId]), rdr[fieldNameDesc].ToString());
                    list.Add(val);
                };
            }

            return list;
        }

        private List<KeyValuePair<int, string>> initializeEngineTypeListData()
        {
            List<KeyValuePair<int, string>> list = new List<KeyValuePair<int, string>>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("InitializeEngineList", con);

                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    CarEngineType engType = new CarEngineType();
                    engType.EngineId = Convert.ToInt32(rdr["car_engine_type_id"]);
                    engType.EnginePower = Convert.ToDecimal(rdr["engine_power"]);
                    engType.IsAutomatic = (bool)rdr["is_automatic"];
                    engType.EngineDescription = rdr["engine_description"].ToString();
                    val = new KeyValuePair<int, string>(engType.EngineId, engType.FullDescription);
                    list.Add(val);
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
                    car.CarTrimLevelId = Convert.ToInt32(rdr["car_trim_level_id"]);
                    car.CarMakeId = Convert.ToInt32(rdr["car_make_id"]);
                    car.CarModelId = Convert.ToInt32(rdr["car_model_id"]);
                    car.Price = Convert.ToDecimal(rdr["price"]);
                    car.NumInStock = Convert.ToInt32(rdr["num_in_stock"]);
                    car.setEngineTypeDetails(Convert.ToInt32(rdr["car_engine_type_id"]), 
                                             rdr["engine_description"].ToString(),
                                             (bool)rdr["is_automatic"],
                                             Convert.ToDecimal(rdr["engine_power"]));

                    car.Features = new List<KeyValuePair<int, string>>();
                    KeyValuePair<int, string> feat;
                    using (SqlConnection con2 = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd2 = new SqlCommand("FetchCarFeaturesByCarId", con2);
                        cmd2.CommandType = CommandType.StoredProcedure;
                        cmd2.Parameters.AddWithValue("@carid", car.CarId);
                        con2.Open();
                        SqlDataReader rdr2 = cmd2.ExecuteReader();
                        while (rdr2.Read())
                        {
                            feat = new KeyValuePair<int, string>(Convert.ToInt32(rdr2["car_feature_id"]), rdr2["feature_description"].ToString());
                            car.Features.Add(feat); 
                        };
                    }

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
                    car.CarId = Convert.ToInt32(rdr["car_id"]);
                    car.CarTrimLevelId = Convert.ToInt32(rdr["car_trim_level_id"]);
                    car.CarMakeId = Convert.ToInt32(rdr["car_make_id"]);
                    car.CarModelId = Convert.ToInt32(rdr["car_model_id"]);
                    car.Price = Convert.ToDecimal(rdr["car_model_description"]);
                    car.NumInStock = Convert.ToInt32(rdr["num_in_stock"]);
                };
                con.Close();
            }
            return car;
        }

        public void InsertNewCar(Car car)
        {
            System.Diagnostics.Debug.WriteLine("!!!-->> Car Deets" + car.CarMakeId.ToString() + " " + car.CarModelId.ToString() );

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                var cmd = new SqlCommand("CreateCar", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@carMakeId", car.CarMakeId);
                cmd.Parameters.AddWithValue("@carModelId", car.CarModelId);
                cmd.Parameters.AddWithValue("@carTrimLevelId", car.CarTrimLevelId);
                cmd.Parameters.AddWithValue("@carengineTypeId", car.CarEngineId);
                cmd.Parameters.AddWithValue("@price", car.Price);
                cmd.Parameters.AddWithValue("@numStock", car.NumInStock);

                cmd.ExecuteNonQuery(); 
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
                cmd.Parameters.AddWithValue("@carMakeId", car.CarMakeId);
                cmd.Parameters.AddWithValue("@carModelId", car.CarModelId);
                cmd.Parameters.AddWithValue("@carTrimLevelId", car.CarTrimLevelId);
                cmd.Parameters.AddWithValue("@carengineTypeId", car.CarEngineId);
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
