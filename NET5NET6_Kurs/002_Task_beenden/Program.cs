namespace _002_Task_beenden
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Mit welcher Klassen kann man einen Task beenden?

            //CancelationTokenSource -> Gibt bekannt, dass der Task beendet werden soll
            //CancelationToken -> Ist der Empfänger und bekommt mit, wenn ein Task zu beenden freigegeben wurde
            
            CancellationTokenSource cts = new CancellationTokenSource();
            //CancellationToken token = cts.Token;

            try
            {
                Task task = new Task(MeineMethodeMitAbbrechen, cts.Token);
                task.Start(); //Methode wird gestartet und befindet sich in einer Endlosschleife

                //nach drei Sekunden warten, möchten wir den Task beenden 
                Task.Delay(3000).Wait(); //cancellationToken.IsCancellationRequested wird auf True gesetzt (Zeile: 50)

                cts.Cancel(); //Wenn CancellationTokenSource.Cancel aufgerufen wird -> dann wird das CancelattionToken.Is
            }
            finally
            {
                //finally wird immer ausger
                cts.Dispose();
            }


            Console.ReadLine();
        }


        private static void MeineMethodeMitAbbrechen(object param)
        {
            if (param is CancellationToken cancellationToken )
            {
                Task task2 = new Task(SubMethodeInEinemTaskMitAbbrechen, cancellationToken);
                task2.Start();


                try
                {
                    while (true)
                    {
                        Console.WriteLine("sleep...");
                        Task.Delay(50).Wait(); //Wir warten zwischen jeder Ausgaben 50 Milisekunden

                        //Wurde von "aussen" die Cancel-Methode aufgerufen 
                        if (cancellationToken.IsCancellationRequested)
                        {
                            cancellationToken.ThrowIfCancellationRequested(); //Wir werfen eine Exception und lassen Methode dadurch beenden 
                        }
                    }
                }
                catch (OperationCanceledException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    //Aufräumarbeiten 
                }
            }
        }

        private static void SubMethodeInEinemTaskMitAbbrechen(object param)
        {
            if (param is CancellationToken cancellationToken)
            {
                try
                {
                    while (true)
                    {
                        Console.WriteLine("schnarchi...");
                        Task.Delay(50).Wait(); //Wir warten zwischen jeder Ausgaben 50 Milisekunden

                        //Wurde von "aussen" die Cancel-Methode aufgerufen 
                        if (cancellationToken.IsCancellationRequested)
                        {
                            cancellationToken.ThrowIfCancellationRequested(); //Wir werfen eine Exception und lassen Methode dadurch beenden 
                        }
                    }
                }
                catch (OperationCanceledException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}