using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace VW_CarStock_Classes
{
    public interface ICarStockDataAccess
    {
        IList<Car> GetCarStock();
        Car GetCarStockById(int id);
        void InsertNewCar(Car car);
        void UpdateCarStock(Car car);
        void DeleteCar(Car car);

    }
}
