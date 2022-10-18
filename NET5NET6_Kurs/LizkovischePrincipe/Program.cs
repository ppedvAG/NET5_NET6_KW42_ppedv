namespace LizkovischePrincipe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    #region Bad Code
    public class Erdbeere
    {
        public string GetColor()
            => "rot";
    }


    public class Kirche : Erdbeere
    {
        public string GetColor()
            => base.GetColor();
    }
    #endregion

    #region Gute Variante

    public abstract class Fruit
    {
        public abstract string GetColor();
    }


    public class Banana : Fruit
    {
        public override string GetColor()
        {
            return "gelb";
        }
    }


    public class Zitrone : Fruit
    {
        public override string GetColor()
        {
            return "gelb";
        }
    }

    #endregion
}