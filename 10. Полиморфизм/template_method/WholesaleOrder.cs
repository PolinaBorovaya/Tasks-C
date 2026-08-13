using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Полиморфизм
{
    public class WholesaleOrder : OrderProcessor
    {
        protected override void ValidateOrder(string product, int quantity)
        {
            Console.WriteLine($"Проверка оптового заказа: {product}, {quantity} шт.");
            if (quantity < 50)
                throw new Exception("Для оптового заказа минимум 50 единиц");
        }

        protected override void CalculatePrice(string product, int quantity)
        {
            decimal price = 80m;
            decimal discount = 0.15m;
            decimal total = price * quantity * (1 - discount);
            Console.WriteLine($"Цена со скидкой 15%: {total:C}");
        }

        protected override bool NeedAdditionalCheck()
        {
            return true;
        }

        protected override void AdditionalCheck(string product)
        {
            Console.WriteLine($"Проверка сертификатов качества для {product}");
        }
    }
}
