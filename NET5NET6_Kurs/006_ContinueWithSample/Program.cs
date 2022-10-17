namespace _006_ContinueWithSample
{
    internal class Program
    {
        private static int[] lottozahlen = new int[7];
        static void Main(string[] args)
        {
            //Was ist ContinueWith -> Wird verwendet, wenn man nach einem Task, einen oder mehrere Task starten möchte 

            //Anonyme Methode (ja man könnte auch diese Methode auslagern und aufrufen ;-) 
            Task t1 = new Task(()=>
            {
                Console.WriteLine("Task1 - Lottozahlen werden ermittelt");

                lottozahlen[0] = 2;
                lottozahlen[1] = 12;
                lottozahlen[2] = 23;
                lottozahlen[3] = 35;
                lottozahlen[4] = 43;
                lottozahlen[5] = 50;
                lottozahlen[6] = 51;

                throw new Exception();
            });

            t1.Start();

            //ContinueWith hat 2 Aufgaben:
            // - Wartet bis der vorige Task (t1) fertig ist (Callback->Wait, WaitAll oder WaitAny) 


            //Variante 1 -> Wie erstellen wir eineVerkettung von Tasks 

            //1.) Allgemeiner Folgetask wird immer gestartet
            t1.ContinueWith(t => AllgemeinerFolgetask());

            //2.) Folgetask bei Fehler
            t1.ContinueWith(t => FolgetaskBeiFehler(), TaskContinuationOptions.OnlyOnFaulted);

            //3.) Folgetask wenn voriger Methode ohne Fehler durchgelaufen ist
            t1.ContinueWith(t => FolgetaskBeiErfolg(), TaskContinuationOptions.OnlyOnRanToCompletion);


            Console.ReadLine();
        }

        private static void AllgemeinerFolgetask()
            => Console.WriteLine("Werde immer aufgerufen....vielleicht für Logging");

        private static void AllgemeinerFolgetask2()
             => Console.WriteLine("Werde auch immer aufgerufen");


        private static void FolgetaskBeiFehler()
            => Console.WriteLine("Werde Aufgerufen, wenn die Lottoziehung einen Fehler erfährt -> für Aufräumarbeiten");

        private static void FolgetaskBeiErfolg()
            => Console.WriteLine("Werde im Erfolgsfall aufgerufen");
    }
}