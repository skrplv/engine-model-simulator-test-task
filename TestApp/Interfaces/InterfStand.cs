using System.Collections.Generic;
using TestApp.Types;

namespace TestApp.Interfaces
{
    public interface InterfStand
    {
        public void StartTest(InterfDvigatel Engine, params double[] ps);
        public void Update(InterfDvigatel Engine);
    }
}
