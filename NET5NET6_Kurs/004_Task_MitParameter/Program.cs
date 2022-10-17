namespace _004_Task_MitParameter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Katze katze = new(); //shortcut -> Katze katze = new Katze();

            //Variante 1 

            //Generisches Task -> Task<T> wird verwenden, um Methode mit einem Rückgabewert aufzurufen.
            //Task<T> -> T ist der Rückgabetyp
            //Task -> arbeitet nur mit Methoden zusammen, die kein Rückgabewert liefern (void) 
            
            Task<string> task1 = new Task<string>(MachEtwas, katze);
            task1.Start();
            task1.Wait();

            //Der Typ von der Property 'Result' leitet sich von der Definition von Task<T> ab. 
            Console.WriteLine(task1.Result);


            //Variante 2 
            Task<string> task2 = new Task<string>(() => MachEtwas(katze));
            task2.Start();
            task2.Wait();
            Console.WriteLine(task2.Result);


            //Variante 3
            Task<string> task3 = Task.Factory.StartNew(MachEtwas, katze);
            task3.Wait();
            Console.WriteLine(task3.Result);


            //Task.Run 
            Task<string> task4 = Task.Run(() => MachEtwas(katze));
            task4.Wait();

            string result = task4.Result;


            Console.ReadLine();


        }

        private static string MachEtwas(object input)
        {
            if (input is Katze katze)
                return katze.Name;

            throw new ArgumentException();
        }
    }

   

    public class Katze
    {
        public string Name { get; set; } = "Maya";
    } 
}