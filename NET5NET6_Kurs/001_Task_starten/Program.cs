
//using System.Threading
//using System.Threading.Task
using System;
using System.Diagnostics;

namespace _001_Task_starten
{
    //TPL gibt es seit .NET 4.0 
    //Namespace: System.Threading.Task -> TPL 
    // (Früher Thread -> System.Threading) 
    internal class Program
    {
        static void Main(string[] args)
        {
            Task task = new Task(MachEtwasInEinemTask); //Funktionszeiger -> Der Task weiß, wo die Methode im Arbeitsspeicher liegt 

            //Starten wir die Methode MachEtwasInEinemTask ... in einem Task 
            task.Start();

            //Wir wollen warten, bis die Task-Methode (MachEtwasInEinemTask) fertig ist
            //Callback geschieht hier
            task.Wait();

            for (int i = 0; i < 1000; i++)
                Console.WriteLine("*");

            Console.ReadLine();
        }


        private static void  MachEtwasInEinemTask()
        {
            for (int i = 0; i < 5000; i++)
               Console.WriteLine($"{i} #");
        }
    }
}