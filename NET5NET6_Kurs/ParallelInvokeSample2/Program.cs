using System.Diagnostics;

namespace ParallelInvokeSample2
{
    internal class Program
    {
        static void Main(string[] args)
        {


            #region Sample1

            //Create an instance of ParallelOptions class
            var parallelOptions = new ParallelOptions()
            {
                MaxDegreeOfParallelism = 2,
            };

            try
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
               
                Parallel.Invoke(
                        parallelOptions,
                        () => DoSomeTask(1),
                        () => DoSomeTask(2),
                        () => DoSomeTask(3),
                        () => DoSomeTask(4),
                        () => DoSomeTask(5),
                        () => DoSomeTask(6),
                        () => DoSomeTask(7)
                    );
                stopwatch.Stop();
                Console.WriteLine($"Time Taken to Execute all the Methods : {stopwatch.ElapsedMilliseconds / 1000.0} Seconds");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            #endregion

            Console.ReadLine();
        }



        /* 
         * Sample 2 soll nach 7 Sekunden alle Parallel-Operationen schließen
         */
        static void Main_Sample2(string[] args)
        {
            //Erstelle eine Instanz von CancellationTokenSource
            CancellationTokenSource cts = new CancellationTokenSource();
            
            
            //Gebe an, dass nach 5 Sekunden Cancel ausgeführt wird
            cts.CancelAfter(TimeSpan.FromSeconds(7));


            //Erstelle ParallelOptions 
            var parallelOptions = new ParallelOptions()
            {
                //2 Task dürfen Parallel nur ausgeführt werden
                MaxDegreeOfParallelism = 2,

                //Übergebe das CancellationToken - Object
                CancellationToken = cts.Token
            };
            try
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                //Passing ParallelOptions as the first parameter
                Parallel.Invoke(
                        parallelOptions,
                        () => DoSomeTask(1),
                        () => DoSomeTask(2),
                        () => DoSomeTask(3),
                        () => DoSomeTask(4),
                        () => DoSomeTask(5),
                        () => DoSomeTask(6),
                        () => DoSomeTask(7)
                    );
                stopwatch.Stop();
                Console.WriteLine($"Time Taken to Execute all the Methods : {stopwatch.ElapsedMilliseconds / 1000.0} Seconds");
            }
            //When the token cancelled, it will throw an exception
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                //Finally dispose the CancellationTokenSource and set its value to null
                cts.Dispose();
                cts = null;
            }
            Console.ReadLine();
        }


        static void Main_Sample3(string[] args)
        {
            //Erstelle CancellationTokenSource
            CancellationTokenSource cts = new CancellationTokenSource();
            
            cts.CancelAfter(TimeSpan.FromSeconds(7));
            
            //Erstelle ParallelOptions class
            ParallelOptions parallelOptions = new ParallelOptions()
            {
                MaxDegreeOfParallelism = 2,
                //Set the CancellationToken value
                CancellationToken = cts.Token
            };


            try
            {
                List<int> integerList = Enumerable.Range(0, 20).ToList();
                Parallel.ForEach(integerList, parallelOptions, i =>
                {
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                    Console.WriteLine($"Value of i = {i}, thread = {Thread.CurrentThread.ManagedThreadId}");
                });
            }
            //When the token canceled, it will throw an exception
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                //Finally dispose the CancellationTokenSource and set its value to null
                cts.Dispose();
                cts = null;
            }
            Console.ReadLine();
        }

        static void DoSomeTask(int number)
        {
            Console.WriteLine($"DoSomeTask {number} started by Thread {Thread.CurrentThread.ManagedThreadId}");
            //Sleep for 2 seconds
            Thread.Sleep(TimeSpan.FromSeconds(2));
            Console.WriteLine($"DoSomeTask {number} completed by Thread {Thread.CurrentThread.ManagedThreadId}");
        }

        static void DoSleepFor()
        {
            while (true)
            {
                global::System.Console.WriteLine("schnaaaaaarch....");
            }
        }
    }

        
}