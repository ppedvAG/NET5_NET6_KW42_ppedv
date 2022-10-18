using System.Runtime.CompilerServices;

namespace AsyncAwaitSample2
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //WriteTextAfter10Sek().Wait();
            //await WriteTextAfter10Sek();
            Task task1 = WriteTextAfter10Sek();
            Task task2 = WriteTextAfter15Sek();
            Task task3 = WriteTextAfter20Sek();
            
            Console.WriteLine("Drücken Sie einen Key um das Programm zu beenden");
            Console.ReadLine();

            Task.WaitAll(task1, task2, task3);
        }

        private static async Task WriteTextAfter10Sek()
        {
            await Task.Delay(10000);
            Console.WriteLine("Text after 10 Sec");
        }

        private static async Task WriteTextAfter15Sek()
        {
            await Task.Delay(15000);
            Console.WriteLine("Text after 15 Sec");
        }

        private static async Task WriteTextAfter20Sek()
        {
            await Task.Delay(20000);
            Console.WriteLine("Text after 20 Sec");
        }

       
    }
}