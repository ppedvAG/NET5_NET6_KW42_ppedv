namespace SingleResponsibilityPrincipe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }


    #region unschöner Source-Code
   
    public class BadEmployee
    {
        //Datenstruktur 
        public int Id { get; set; }
        public string Name { get; set; }

        //DataAccess Layer
        public void AddEmployeeToDb()
        {
            Console.WriteLine("Speichere Employee in DB");
        }


        //Service-Layer oder im Monolith->UI 
        public void GenerateReport()
        {
            Console.WriteLine("Erstelle ein Report von Employee");
        }
    }
    #endregion

    #region Bessere Variante
    public class Employee
    {
        //Datenstruktur 
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class EmployeeRepository
    {
        public void AddEmployeeToDb()
        {
            Console.WriteLine("Speichere Employee in DB");
        }
    }


    public class ReportGenerator
    {
        //Service-Layer oder im Monolith->UI 
        public void GenerateReport()
        {
            Console.WriteLine("Erstelle ein Report von Employee");
        }
    }
    #endregion
}