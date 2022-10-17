namespace _005_Task_mit_Exceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task t1 = null, t2 = null, t3 = null, t4 = null;

            try
            {
                t1 = new Task(MachEinenFehler1);
                t1.Start();


                t2 = Task.Factory.StartNew(MachEinenFehler2);

                t3 = Task.Run(MachEinenFehler3);

                t4 = Task.Run(MachKeinenFehler);

                //Wir warten bis ALLE TASK fertig sind

                Task.WaitAll(t1, t2, t3, t4); //Wir erfahren erst beim Callback (Wait oder WaitAll), dass der verwendete Task einen Fehler erhalten hat.
                
            }
            catch(AggregateException ex) //AggregateException ist für TPL geschrieben 
            {
                foreach (Exception innerException in ex.InnerExceptions)
                {
                    Console.WriteLine(innerException.Message);
                }
            }

            Console.WriteLine("BEISPIEL 2: Task Zustände");
            //Task 3 (Mit Fehler)
            if (t3.IsCompleted)
                Console.WriteLine("Task 3 ist fertig durchgelaufen");

            if (t3.IsCompletedSuccessfully)
                Console.WriteLine("Task 3 ist ohne Fehler fertig durchgelaufen");

            if (t3.IsFaulted) 
                Console.WriteLine("Methode in Task 3 hat einen Fehler verursach");

            if (t3.IsCanceled)
                Console.WriteLine("Methode wurde beendet");


            //TASK 4b(Ohne Fehler) 
            if (t4.IsCompleted)
                Console.WriteLine("Task 4 ist fertig durchgelaufen");

            if (t4.IsCompletedSuccessfully)
                Console.WriteLine("Task 4 ist ohne Fehler fertig durchgelaufen");

            if (t4.IsFaulted)
                Console.WriteLine("Methode in Task 4 hat einen Fehler verursach");

            if (t4.IsCanceled)
                Console.WriteLine("Methode wurde beendet");
        }


        private static void MachEinenFehler1()
        {
            Task.Delay(3000).Wait();
            throw new DivideByZeroException();
        }

        private static void MachEinenFehler2()
        {
            Task.Delay(6000).Wait();
            throw new StackOverflowException();
        }

        private static void MachEinenFehler3()
        {
            Task.Delay(9000).Wait();
            throw new OutOfMemoryException();
        }

        private static void MachKeinenFehler()
            => Console.WriteLine("Hallo liebe Teilnehmer");
    }
}