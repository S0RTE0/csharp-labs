namespace Program
{
    public class Employee
    {
        public string Name { get; private set; }
        public string Position { get; private set; }
        public decimal BaseSalary { get; private set; }

        public Employee(string name, string position, decimal baseSalary)
        {
            Name = name;
            Position = position;
            BaseSalary = baseSalary;
        }

        public virtual decimal CalculateSalary()
        {
            return BaseSalary;
        }

        public virtual string GetInfo()
        {
            return $"Name: {Name} | Position: {Position} | Total Salary: {CalculateSalary()}";
        }
    }

    public class Developer : Employee
    {
        public int LinesOfCode { get; private set; }

        public Developer(string name, decimal baseSalary, int linesOfCode)
            : base(name, "Developer", baseSalary)
        {
            LinesOfCode = linesOfCode;
        }

        public override decimal CalculateSalary()
        {
            return base.CalculateSalary() + (LinesOfCode * 0.5m);
        }

        public override string GetInfo()
        {
            return base.GetInfo() + $" | Lines of Code: {LinesOfCode}";
        }
    }

    public class Manager : Employee
    {
        public int SubordinatesCount { get; private set; }

        public Manager(string name, decimal baseSalary, int subordinatesCount)
            : base(name, "Manager", baseSalary)
        {
            SubordinatesCount = subordinatesCount;
        }

        public override decimal CalculateSalary()
        {
            return base.CalculateSalary() + (SubordinatesCount * 1000m);
        }

        public override string GetInfo()
        {
            return base.GetInfo() + $" | Subordinates: {SubordinatesCount}";
        }
    }

    public class QAEngineer : Employee
    {
        public int TestCasesWritten { get; private set; }

        public QAEngineer(string name, decimal baseSalary, int testCasesWritten)
            : base(name, "QA Engineer", baseSalary)
        {
            TestCasesWritten = testCasesWritten;
        }

        public override decimal CalculateSalary()
        {
            return base.CalculateSalary() + (TestCasesWritten * 50m);
        }

        public override string GetInfo()
        {
            return base.GetInfo() + $" | Test Cases: {TestCasesWritten}";
        }
    }

    public class BusinessAnalyst : Employee
    {
        public int ClientMeetings { get; private set; }

        public BusinessAnalyst(string name, decimal baseSalary, int clientMeetings)
            : base(name, "Business Analyst", baseSalary)
        {
            ClientMeetings = clientMeetings;
        }

        public override decimal CalculateSalary()
        {
            return base.CalculateSalary() + (ClientMeetings * 800m);
        }

        public override string GetInfo()
        {
            return base.GetInfo() + $" | Client Meetings: {ClientMeetings}";
        }
    }

    public class Company
    {
        private List<Employee> employees = new List<Employee>();

        public void AddEmployee(Employee employee)
        {
            employees.Add(employee);
        }

        public void ShowAllEmployees()
        {
            Console.WriteLine("--- Employee Directory ---");
            foreach (var employee in employees)
            {
                Console.WriteLine(employee.GetInfo());
            }

            Console.WriteLine("--------------------------\n");
        }

        public void CalculateTotalPayroll()
        {
            decimal totalPayroll = 0;
            foreach (var employee in employees)
            {
                totalPayroll += employee.CalculateSalary();
            }

            Console.WriteLine($"Total Company Payroll: {totalPayroll}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Company myCompany = new Company();

            Developer dev = new Developer("Babrian", 30000m, 5000);
            Manager mgr = new Manager("Bima", 40000m, 5);
            QAEngineer qa = new QAEngineer("Boba", 28000m, 120);
            BusinessAnalyst ba = new BusinessAnalyst("Shtush", 35000m, 10);

            myCompany.AddEmployee(dev);
            myCompany.AddEmployee(mgr);
            myCompany.AddEmployee(qa);
            myCompany.AddEmployee(ba);

            myCompany.ShowAllEmployees();
            myCompany.CalculateTotalPayroll();
        }
    }
}
