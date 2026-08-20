using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Полиморфизм
{
    public class ExpressOrder : OrderProcessor
    {
        protected override void ValidateOrder(string product, int quantity)
        {
            Console.WriteLine($"Проверка экспресс заказа: {product}, {quantity} шт.");
            if (quantity <= 0 || quantity > 10)
                throw new Exception("Для экспресс доставки максимум 10 единиц");
        }

        protected override void CalculatePrice(string product, int quantity)
        {
            decimal price = 100m;
            decimal total = price * quantity;
            decimal delivery = 50m;
            Console.WriteLine($"Стоимость: {total:C}, доставка: {delivery:C}, итого: {total + delivery:C}");
        }

        protected override bool NeedAdditionalCheck()
        {
            return true;
        }

        protected override void AdditionalCheck(string product)
        {
            Console.WriteLine($"Дополнительная проверка товара {product} на наличие на складе");
        }

        protected override void ConfirmOrder()
        {
            Console.WriteLine("Экспресс заказ подтвержден, отправлено SMS уведомление");
        }
    }
}
