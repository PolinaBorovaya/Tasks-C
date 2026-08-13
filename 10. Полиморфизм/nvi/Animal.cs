using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Полиморфизм.nvi
{
    public abstract class Animal
    {
        public void Speak()
        {
            Console.Write($"{GetType().Name}: ");
            Console.WriteLine(GetSound());
        }

        public void Walk()
        {
            Console.Write($"{GetType().Name}: ");
            Console.WriteLine(GetMove());
        }

        protected abstract string GetSound();
        protected abstract string GetMove();
    }

    public class Dog : Animal
    {
        protected override string GetSound() => "Гав-гав!";
        protected override string GetMove() => "бежит";
    }

    public class Cat : Animal
    {
        protected override string GetSound() => "Мяу-мяу!";
        protected override string GetMove() => "крадется";
    }

    public class Bird : Animal
    {
        protected override string GetSound() => "Чирик-чик!";
        protected override string GetMove() => "летит";
    }
}
