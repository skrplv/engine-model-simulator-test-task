
using TestApp.Types;

namespace TestApp.Interfaces
{
    public interface InterfDvigatel
    {
        public bool Start { get; set; }
        public TypesOfDvigatel  TypesOfDvigatel {get; set;}
        public void LaunchSimulation(double tAir);

        #region Наблюдатель 
        void Attach(InterfStand observer);
        void Detach();
        void Notify();
        #endregion

    }
}
