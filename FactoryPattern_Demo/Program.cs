using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            AssemblyFactory factory = new AssemblyFactory();
            var partName1 = factory.GetParts("Spindle");
            var partName2 = factory.GetParts("Gear");
            Console.WriteLine($"The assembly is made from {partName1.GetSKU()} : {partName1.GetPartDescription()} and {partName2.GetSKU()} : {partName2.GetPartDescription()}");
            Console.ReadLine();
        }
    }

    public interface IPart
    {
        string GetSKU();
        string GetPartDescription();
    }

    public class Gear : IPart
    {
        public string GetSKU()
        {
            return "GR0001";
        }

        public string GetPartDescription()
        {
            return "35 tooth helical gear";
        }
    }

    public class Spindle : IPart
    {
        public string GetSKU()
        {
            return "SP0001";
        }
        public string GetPartDescription()
        {
            return "9 hollow threaded spindle"; 
        }
    }

    public class AssemblyFactory
    {
        public IPart GetParts(string partName)
        {
            switch(partName)
            {
                case "Spindle":
                    return new Spindle();
                case "Gear":
                    return new Gear();
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
