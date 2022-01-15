using VW_CarStock_Classes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace VW_CarStock_Classes
{
    public interface ICarStock
    {
        IList<CarStock> GetCarStock();
        CarStock GetCarStockById(int? id);
        void InsertNew(CarStock carstock);
        void UpdateCarStock(CarStock carstock);
        void Delete(CarStock carstock);
    }
}
