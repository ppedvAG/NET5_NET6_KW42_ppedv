namespace InterfaceSegerationPrincipe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }


    #region BadCode


    public interface IVehicle
    {
        void Drive();
        void Fly();
        void Swim(); 
    }


    public class Vehicle : IVehicle
    {
        public void Drive()
        {
            Console.WriteLine("Fahren");
        }

        public void Fly()
        {
            Console.WriteLine("Fliegen");
        }

        public void Swim()
        {
            Console.WriteLine("Swimm");
        }
    }


    public class AmphibischesFahrzeug : IVehicle
    {
        public void Drive()
        {
            Console.WriteLine("Fahren");
        }

        public void Swim()
        {
            Console.WriteLine("Swimm");
        }

        public void Fly()
        {
            throw new NotImplementedException();
        }
    }
    #endregion

    #region Good Code

    public interface IFly
    {
        void Fly();
    }

    public interface IDrive
    {
        void Drive();
    }

    public interface ISwim
    {
        void Swim();
    }


    public class AmphibischesFahrzeug2 : ISwim, IDrive
    {
        public void Drive()
        {
            Console.WriteLine("Fahren");
        }

        public void Swim()
        {
            Console.WriteLine("schwimmen");
        }
    }

    #endregion
}