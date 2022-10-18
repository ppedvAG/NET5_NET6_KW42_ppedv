namespace DependencyInversionPrincipe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ICarService carService = new CarService();


            //Für Testzwecke (Tag 4 und Tag 5) 
            carService.Repair(new MockCar());

            //Tag 5 oder 6 wird Car verwenden 
            carService.Repair(new Car());


        }
    }

    #region unschönes Beispiel

    //Programmierer A: 5 Tage -> (Tag 1 bis Tag 5) 
    public class BadCar
    {
        public string Marke { get; set; }
        public string Modell { get; set; }
        public int ConstructionYear { get; set; }
    }

    //Programmierer B: 3 Tage -> Tag 5 bis Tag 8
    public class BadCarService
    {
        public void Repair (BadCar car) //Feste Kopplung -> (-) Wechselwirkung
        {
            Console.WriteLine("Auto wird repariert");
        }
    }
    #endregion


    #region Dependency Invesion

    public interface ICar
    {
        string Marke { get; set;}
        string Modell { get; set; }
        int ConstructionYear { get; set; }  
    }

    public interface ICarService
    {
        void Repair(ICar car); //Lose Kopplung 
    }


    //Programmerer A: 5 Tage -> Tag 1 bis Tag 5 

    public class Car : ICar
    {
        public string Marke { get; set; }
        public string Modell { get; set; }
        public int ConstructionYear { get; set; }
    }

    //Programmierer B: 3 Tage -> Tag 1 bis Tag 3
    public class CarService : ICarService
    {
        public void Repair(ICar car)
        {
            Console.WriteLine("Auto wird repariert");
        }
    }


    public class MockCar : ICar
    {
        public string Marke { get; set; } = "VW";
        public string Modell { get; set; } = "POLO";
        public int ConstructionYear { get; set; } = 2020;
    }



    #endregion
}