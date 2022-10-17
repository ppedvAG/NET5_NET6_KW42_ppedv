namespace _003_TaskFactorySample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region .NET 4.0
            //Variante 1:
            Task task1 = new Task(MacheEtwasInEinemThread);
            task1.Start();
            task1.Wait();

            //Variante 2: 
            Task task2 = Task.Factory.StartNew(MacheEtwasInEinemThread); // Task.Start erfolgt automatische
            task2.Wait();
            #endregion


            #region Variante 3 - .NET 4.5 

            //Variante 3
            Task task3 = Task.Run(MacheEtwasInEinemThread); //Ist nur eine verkürzte Schreibweise gegenüber Task.Factory.StartNew
            task3.Wait();
            #endregion


            Console.ReadLine();
        }

        private static void MacheEtwasInEinemThread()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("*");
            }
        }
    }
}