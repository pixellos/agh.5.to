using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    [Flags]
    public enum Position
    {
        Manager = 1,
        Technican = 2,
        Director = 4,
        Warehouser = 8
    }

    public class Employee
    {
        public Employee(string firstName, string lastName, Position position, int baseSalary, Dictionary<string, int> specialBonuses)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Position = position;
            this.BaseSalary = baseSalary;
            this.SpecialBonuses = specialBonuses;
        }

        public string FirstName { get;  }
        public string LastName { get;  }
        public Position Position { get; }
        public IReadOnlyDictionary<string, int> SpecialBonuses { get; set; } = new Dictionary<string, int>();
        public int BaseSalary { get; }
    }
}
