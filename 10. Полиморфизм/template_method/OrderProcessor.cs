using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Полиморфизм
{
    public abstract class OrderProcessor
    {
        public void ProcessOrder(string product, int quantity)
        {
            Console.WriteLine("Обработка заказа");

            ValidateOrder(product, quantity);
            CalculatePrice(product, quantity);

            if (NeedAdditionalCheck())
            {
                AdditionalCheck(product);
            }

            ConfirmOrder();

            Console.WriteLine("Заказ обработан\n");
        }

        protected abstract void ValidateOrder(string product, int quantity);
        protected abstract void CalculatePrice(string product, int quantity);

        protected virtual void ConfirmOrder()
        {
            Console.WriteLine("Заказ подтвержден стандартным способом");
        }

        protected virtual bool NeedAdditionalCheck()
        {
            return false;
        }

        protected virtual void AdditionalCheck(string product)
        {
            Console.WriteLine("Дополнительная проверка товара");
        }
    }
}
