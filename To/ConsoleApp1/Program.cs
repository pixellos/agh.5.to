using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public interface IPrinter
    {
        public void Print(Employee e);
    }

    public class ConsoleJsonPrinter : IPrinter
    {
        public void Print(Employee e)
        {
            var o = Newtonsoft.Json.JsonConvert.SerializeObject(e, Newtonsoft.Json.Formatting.Indented);
            Console.WriteLine(o);
        }
    }

    public class ConsoleJsonPrinterWithCalc : IPrinter
    {
        public ConsoleJsonPrinterWithCalc(ISalaryCalculator sc)
        {
            this.Sc = sc;
        }

        public ISalaryCalculator Sc { get; }

        public void Print(Employee e)
        {
            var salary = this.Sc.Calculate(e);
            var o = Newtonsoft.Json.JsonConvert.SerializeObject(new { Person = e, Salary = salary }, Newtonsoft.Json.Formatting.Indented);
            Console.WriteLine(o);
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            var e1 = new Employee("Marek", "Kowalski", Position.Director, 1000, new System.Collections.Generic.Dictionary<string, int>() { { "CTO", 1020 } });
            var e2 = new Employee("Marek", "Kowalskiewicz", Position.Manager, 1000, new System.Collections.Generic.Dictionary<string, int>() { { "Manager", 200 } });
            var e3 = new Employee("Marek", "Kowalski", Position.Director, 1000, new System.Collections.Generic.Dictionary<string, int>() { { "CTO", 1020 } });
            var e4 = new Employee("Marek", "Kowalski", Position.Director, 1000, new System.Collections.Generic.Dictionary<string, int>() { { "CTO", 1020 } });
            var es = new List<Employee>() { e1, e2, e3, e4 };

            ISalaryCalculator calculator = new NormalSalaryCalculator();
            IPrinter printer = new ConsoleJsonPrinter();

            foreach (var e in es)
            {
                printer.Print(e);
            }


            // 2

            calculator = new NormalSalaryCalculator();
            printer = new ConsoleJsonPrinterWithCalc(calculator);

            foreach (var e in es)
            {
                printer.Print(e);
            }
        }
    }
}
