using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class NormalSalaryCalculator : ISalaryCalculator
    {
        public int Calculate(Employee employee)
        {
            return employee.BaseSalary + (employee.SpecialBonuses.TryGetValue(Enum.GetName(typeof(Position),  employee.Position), out int value) ? value : 0);
        }
    }

}