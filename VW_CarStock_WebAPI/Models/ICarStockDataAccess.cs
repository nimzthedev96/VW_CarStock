using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace VW_CarStock_WebAPI
{
    public interface ICarStockDataAccess
    {
        IList<CarStock> GetCarStock();
        CarStock GetCarStockById(int id);
        void InsertNewCar(CarStock carStock);
        void UpdateCarStock(CarStock carStock);
        void DeleteCar(CarStock carStock);

    }
}
