using System;
using System.Collections.Generic;
using TestApp.Sozdateli;
using TestApp.Types;
using TestApp.Interfaces;
namespace TestApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            SozdDvigatel creator = new();
            double temp = 0;
            bool flag = true;

            do
            {
                try
                {
                    Console.WriteLine("ввод температуры окружающей среды в градусах Цельсия");
                    temp = Convert.ToDouble(Console.ReadLine());
                    flag = false;
                }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine(e.Message);
                }

            } while (flag);

            InterfDvigatel engine;
            try
            {
                engine = creator.GetEngine("../../../VhodParam.json", TypesOfDvigatel.InternalCombucstion);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            Stand stand = new(new List<TypesOfTests>() { TypesOfTests.MaximumTemperature });

            engine.Attach(stand);
            stand.StartTest(engine, temp);

        }
    }
}
