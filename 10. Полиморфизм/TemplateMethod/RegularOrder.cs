using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Полиморфизм
{
    public class RegularOrder : OrderProcessor
    {
        protected override void ValidateOrder(string product, int quantity)
        {
            Console.WriteLine($"Проверка обычного заказа: {product}, {quantity} шт.");
            if (quantity <= 0)
                throw new Exception("Количество должно быть больше 0");
        }

        protected override void CalculatePrice(string product, int quantity)
        {
            decimal price = 100m;
            decimal total = price * quantity;
            Console.WriteLine($"Стоимость: {total:C}");
        }

        protected override void ConfirmOrder()
        {
            Console.WriteLine("Заказ подтвержден, отправлено письмо клиенту");
        }
    }
}
