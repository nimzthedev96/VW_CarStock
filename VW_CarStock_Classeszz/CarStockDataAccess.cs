
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

        CarStockDataAccess(string cs)
        {
            connectionString = cs;
        }

        /* Return a list of CarStock objects */
        public IList<CarStock> GetCarStock()
        {
            List<CarStock> carStock_List = new List<CarStock>();

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var carStock_Item = new CarStock()
                    /*{
                        Id = Convert.ToInt32(rdr["Id"]),
                        Name = rdr["Name"].ToString(),
                        Position = rdr["Position"].ToString(),
                        Office = rdr["Office"].ToString(),
                        Age = Convert.ToInt32(rdr["Age"]),
                        Salary = Convert.ToInt32(rdr["Salary"])
                    };*/

                    carStockList.Add(carStock_Item);
                }
                return (carStock_List);
            }

        }

        /* Return a single CarStock object */
        public CarStock GetCarStockById(int id)
        {
            CarStock carStock = new CarStock();


            return carStock;

        }

        public void InsertNew(CarStock carstock)
        {


        }

        public void UpdateCarStock(CarStock carstock)
        {

        }

        public void Delete(CarStock carstock)
        {

        }
    }
}
