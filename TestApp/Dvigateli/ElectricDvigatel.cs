using System;
using TestApp.Types;
using TestApp.Interfaces;

namespace TestApp.Dvigateli
{
    public class ElectricDvigatel : InterfDvigatel
    {
        public TypesOfDvigatel TypesOfDvigatel { get; set; }
        public bool Start { get; set; }

        public void LaunchSimulation(double tAir) // запуск симуляции
        {
            throw new NotImplementedException();
        }
        
        #region Наблюдатель
        public void Attach(InterfStand observer) // подключение
        {
            throw new NotImplementedException();
        }
        public void Detach() // отключение
        {
            throw new NotImplementedException();
        }
        public void Notify() // уведомление
        {
            throw new NotImplementedException();
        }
        #endregion
    
    }
}
