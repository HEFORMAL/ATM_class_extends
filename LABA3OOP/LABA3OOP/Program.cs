using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace LABA3OOP     // Чем отличается интерфейс от абстракных классов не считая что нельзя переменные вводить 
{
    class Check
    {
        public static double number()
        {
            while (true)
            {
                string word = Console.ReadLine();


                if (int.TryParse(word, out int number))
                {
                    if (number > 0 && number < 100)
                    {

                        return number;

                    }
                    else if (number == 0)
                    {
                        Console.WriteLine("Ошибка: Вы ввели 0, поменяй на положительное число!");
                    }
                    else if (number >100)
                    {
                        Console.WriteLine("Ошибка: Вы ввели больше 100, поменяй число!");
                    }
                    else
                    {
                        Console.WriteLine("Ошибка: Отрицательное число не допускается!");
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка: Не удалось распознать число, введите цифры!");
                }
            }
        }

    }
   
   
    class ATM
    {

        
        protected List<float> Summ_calls = new List<float>() { 205, 4, 3 }; // минуты звонков 
        private int minets;
        private double calls;

        public void PrintAveragePrice()
        {
            Console.WriteLine($"Среднее стоимость тарифов: {((Summ_calls.Sum()) / Summ_calls.Count())}. "); 
        }
        protected virtual double Calculated(int minets, double calls)
        {
            double cost = minets * calls;
            return cost;
        }
        public void PrintCalculated( int minets, double calls)
        {

            Console.WriteLine($"Стоимость звонков составило: {Calculated(minets, calls)}");
        }


    }
    class StandartTarif : ATM/*, IList*/
    {
        protected override double Calculated(int minets, double calls)
        {
            return base.Calculated(minets, calls);
        }
        


        
    }
    class DiscountedTarif : ATM/*, IList*/
    {
        protected override double Calculated(int minets, double calls)
        {
            Console.WriteLine("Введите скидку по льготе в процентах");
            double discoint = Check.number();
            double costdiscount = minets * calls * (discoint*0.01);
            return costdiscount;
        }

       
    }

    internal class Program // добавить звонока со скидкой с помощью меню и вывод всего 
    {
        static void Main(string[] args)
        {
            

            ATM aTM = new ATM();
            aTM.PrintAveragePrice();

            StandartTarif aST = new StandartTarif();
            aST.PrintCalculated(45,5);

            DiscountedTarif dST = new DiscountedTarif();
            dST.PrintCalculated(45, 5);

        }
    }
}
