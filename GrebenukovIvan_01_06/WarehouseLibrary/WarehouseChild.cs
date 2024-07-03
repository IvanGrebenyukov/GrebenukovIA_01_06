using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace WarehouseLibrary
{
    public class WarehouseChild: BaseWarehouse
    {
        public int YearRelease { get; set; }

        public WarehouseChild(string productName, double price, int count, int yearRelease)
            :base(productName, price, count)
        {
            YearRelease = yearRelease;

            if(yearRelease > DateTime.Now.Year && yearRelease < 1900)
            {
                throw new ArgumentException("Товар не может быть выпущен позже текущего года");
            }

        }

        public override double Quality()
        {
            double quality = base.Quality();
            if(DateTime.Now.Year - YearRelease <= 3)
            {
                return quality + 0.5 * (DateTime.Now.Year - YearRelease);
            } else
            {   
                return quality + 1.3 * (DateTime.Now.Year - YearRelease);
            }
        }

        public override string ToString()
        {
            return $"Название: {ProductName}; Цена: {Price}; Количество: {Count}; Качество класса наследника: {Quality()}";
        }
    }
}
