using VW_CarStock_WebAPI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace VW_CarStock_WebAPI
{
    public class CarStockDataAccess : ICarStockDataAccess
    {
        /* DB connection string to be passed in when instatiating this class */
        private readonly string connectionString;

        public CarStockDataAccess(string cs)
        {
            connectionString = cs;
        }

        /* Return a list of CarStock objects */
        public IList<CarStock> GetCarStock()
        {
            List<CarStock> carStock_List = new List<CarStock>();

            using (SqlConnection con = new SqlConnection(connectionString)) 
            {
                SqlCommand cmd = new SqlCommand("FetchAllCarStock", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    CarStock carStock_Item = new CarStock();
                    /*{
                    Id = Convert.ToInt32(rdr["Id"]),
                    Name = rdr["Name"].ToString(),
                    Position = rdr["Position"].ToString(),
                    Office = rdr["Office"].ToString(),
                    Age = Convert.ToInt32(rdr["Age"]),
                    Salary = Convert.ToInt32(rdr["Salary"])*/

                    carStock_List.Add(carStock_Item);
                };
                 
                return (carStock_List);
            }
        }


        /* Return a single CarStock object */
        public CarStock GetCarStockById(int id)
        {
            CarStock carStock = new CarStock();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("FetchCarStockById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@car_stock_id", id);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    /*{
                    Id = Convert.ToInt32(rdr["Id"]),
                    Name = rdr["Name"].ToString(),
                    Position = rdr["Position"].ToString(),
                    Office = rdr["Office"].ToString(),
                    Age = Convert.ToInt32(rdr["Age"]),
                    Salary = Convert.ToInt32(rdr["Salary"])*/

                };
            }

            return carStock;
        }

        public void InsertNewCar(CarStock carStock)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                var cmd = new SqlCommand("InsertNewCar", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                
                //cmd.Parameters.AddWithValue("@Salary", employee.Salary);
                cmd.ExecuteNonQuery();
            }
        }
    

        public void UpdateCarStock(CarStock carStock)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                var cmd = new SqlCommand("UpdateCarStock", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@car_id", carStock.CarId);
                cmd.Parameters.AddWithValue("@numStock", carStock.NumInStock);
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

        public void DeleteCar(CarStock carStock)
        {
            if (carStock == null) 
                return;

            if (carStock.NumInStock != 0)
                throw new InvalidOperationException("Cannot delete a car for which there is still stock");

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                var cmd = new SqlCommand("DeleteCarStock", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@car_id", carStock.CarId);
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
