using TestApp.Types;

namespace TestApp.Interfaces
{
    public interface InterfSozdatel
    {
        public abstract InterfDvigatel GetEngine(string _pathJson, TypesOfDvigatel type);
    }
}
