using Newtonsoft.Json;
using System;
using System.IO;
using TestApp.Dvigateli;
using TestApp.Types;
using TestApp.Interfaces;
using TestApp.Model;

namespace TestApp.Sozdateli
{
    public class SozdDvigatel : InterfSozdatel
    {
        public InterfDvigatel GetEngine(string _pathJson, TypesOfDvigatel type)
        {
            InterfDvigatel engine = type switch {
                TypesOfDvigatel.Electric => JsonConvert.DeserializeObject<ElectricDvigatel>(File.ReadAllText(_pathJson)),
                TypesOfDvigatel.InternalCombucstion => JsonConvert.DeserializeObject<InternalCombucstionDvigatel>(File.ReadAllText(_pathJson)),
                _ => throw new ArgumentException("Такого типа нет " + type.ToString()),
            };
            engine.TypesOfDvigatel = type;
            return engine;

        }
    }
}

