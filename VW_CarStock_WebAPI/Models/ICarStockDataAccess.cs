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
        void InsertNew(CarStock carstock);
        void UpdateCarStock(CarStock carstock);
        void Delete(CarStock carstock);
    }
}
