
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.TPL_2
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            int[] mas = await GenerateArrayAsync();
            var oddMas = await GetOddNumbersAsync(mas);

            Console.WriteLine("Первые 40 нечётных чисел: ");
            foreach(var num in oddMas.Take(40))
            {
                Console.WriteLine(num);
            }
        }

        static async Task<int[]> GenerateArrayAsync()
        {
            return await Task.Run(() =>
            {
                int[] mas = new int[1000005];
                var rnd = new Random();

                for (int i = 0; i < mas.Length; i++)
                {
                    mas[i] = rnd.Next(1, 1000);
                }

                return mas; 
            });
        }

        static async Task<List<int>> GetOddNumbersAsync(int[] mas)
        {
            return await Task.Run(() =>
            {
                var oddMas = mas
                .AsParallel()
                .Where(x => x % 2 != 0)
                .ToList();

                return oddMas;
            });
        }
    }
}
