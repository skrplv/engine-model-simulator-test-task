using System;
using System.Collections.Generic;
using TestApp.Dvigateli;
using TestApp.Types;
using TestApp.Interfaces;
using TestApp.Model;

namespace TestApp
{
    public class Stand : InterfStand
    {

        #region Параметры и тип теста
        public double ParamError { get; set; } = 10e-1;
        public int MaxTime { get; set; } = 10000;

        private readonly List<TypesOfTests> _typesOfTests = new() { TypesOfTests.MaximumTemperature };
        #endregion

        public Stand(List<TypesOfTests> typesOfTests)
        {
            _typesOfTests = typesOfTests;
        }
        public void StartTest(InterfDvigatel Engine, params double[] vs)
        {
            Engine.Attach(this);
            Engine.LaunchSimulation(vs[0]);
        }

        #region Критическая температура
        private void MaxTemp(InterfDvigatel engine)
        {
            switch (engine.TypesOfDvigatel)
            {
                case TypesOfDvigatel.InternalCombucstion:
                    MaxTemp(engine as InternalCombucstionDvigatel);
                    break;
                case TypesOfDvigatel.Electric:
                    MaxTemp(engine as ElectricDvigatel);
                    break;
                default:
                    throw new ArgumentException("Этот тип двигателя не поддерживается");
            }
        }
        private void MaxTemp(InternalCombucstionDvigatel engine)
        {
            double eps = engine.T - engine.TempDvig;
            engine.Start = eps > ParamError && engine.startTime < MaxTime;
            if (!engine.Start)
            {
                Console.WriteLine("Результаты теста критической температуры:\n" +
                    ((engine.startTime < MaxTime) ?
                    "время, прошедшее с момента старта до перегрева =" + engine.startTime + " секунд"
                    : "Двигатель прошел испытание"));
            }
        }
        private static void MaxTemp(ElectricDvigatel engine)
        {
        }
        #endregion

        #region Наблюдатель
        public void Update(InterfDvigatel Engine)
        {
            foreach (TypesOfTests test in _typesOfTests)
            {
                switch (test)
                {
                    case TypesOfTests.MaximumTemperature:
                        MaxTemp(Engine);
                        break;
                    default:
                        throw new Exception("Стенд не имеет тестов");
                }
            }
        }
        #endregion

    }
}
