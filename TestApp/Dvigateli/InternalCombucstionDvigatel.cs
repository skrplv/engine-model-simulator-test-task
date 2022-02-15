
using System;
using TestApp.Types;
using TestApp.Interfaces;

namespace TestApp.Model
{
    public class InternalCombucstionDvigatel : InterfDvigatel
    {
        private int index = 0;
        private InterfStand _stand = null; // Наблюдатель стенда

        #region Параметры
        public int startTime = 0;
        public bool Start { get; set; } = false;
        public double I { get; set; } //  Момент инерции двигателя
        public int[] M { get; set; } // Кусочно-линейная зависимость крутящего момента, вырабатываемого двигателем
        public int[] V { get; set; } // Cкорость вращения коленвала
        public double T { get; set; } // Температура перегрева
        public double Hm { get; set; } // Коэффициент зависимости скорости нагрева от крутящего момент
        public double Hv { get; set; } // Коэффициент зависимости скорости нагрева от скорости вращения коленвала
        public double C { get; set; } // Коэффициент зависимости скорости охлаждения от температуры двигателя и окружающей среды
        public double TempDvig { get; set; } // температура двигателя
        public double TempAir { get; set; } // температура воздуха
        public TypesOfDvigatel TypesOfDvigatel { get; set; }

        #endregion

        
        public InternalCombucstionDvigatel() { }

        private double PoiskVc() // Рассчет скорости нагрева двигателя (градусы цельсия/сек)
        {
            return C * (TempAir - TempDvig);
        }

        private double PoiskVh() // Рассчет скорости охлаждения двигателя (градусы цельсия/сек)
        {
            return M[index] * Hm + Math.Pow(V[index], 2) * Hv;
        }

        public void LaunchSimulation(double tAir) // запуск симуляции
        {
            Start = true;
            startTime = 0;

            TempAir = tAir;
            TempDvig = TempAir;// Температура двигателя до момента старта равняется температуре окружающей среды

            double v = V[0];
            double m = M[0]; 
            double a = m / I; // ускорение

            while (Start)
            {
                startTime++;
                v += a;
                
                if (index < M.Length - 2)
                {
                    index += v < M[index + 1] ? 0 : 1;
                }
                
                double up = v - V[index]; // Нагрев
                double down = V[index + 1] - V[index]; //  охлаждение
                double factor = M[index + 1] - M[index]; 
                m = up / down * factor + M[index];
                TempDvig += PoiskVc() + PoiskVh();
                a = m / I;
                Notify();
            } 
        }        

        #region Наблюдатель

        public void Attach(InterfStand stand)
        {
            _stand = stand;
        }

        public void Detach()
        {
            _stand = null;
        }
        
        public void Notify()
        {
            _stand.Update(this);
        }
        #endregion

    }
}
