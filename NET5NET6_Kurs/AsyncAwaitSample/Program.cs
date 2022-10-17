namespace AsyncAwaitSample
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            #region Beispiel 1
            string dayTimeResult = await Task.Run(Daytime);

            Task t1 = Task.Run(()=>ShowDayTime(dayTimeResult));
            
            

            Console.WriteLine("Test");

            string translatedDayTime = await Task.Run(()=>TranslateDayTime(dayTimeResult));

            //Call
            await Task.Run(() => ShowDayTime(translatedDayTime));
            #endregion


            
            //Console.ReadLine();
        }



        /// <summary>
        /// Welche Tageszeit ist aktuell? 
        /// </summary>
        /// <returns>morning/afternonn/evening</returns>
        public static string Daytime()
        {
            DateTime dateTime = DateTime.Now;

            return dateTime.Hour > 17 ? "evening" : dateTime.Hour > 12 ? "afternoon" : "morning";
        }

        public static string TranslateDayTime(string daytime)
        {
            string retValue = string.Empty;

            if (daytime == "evening")
                retValue = "Abend";
            else if (daytime == "afternoon")
                retValue = "Nachmittag";
            else
                retValue = "Morgen";

            return retValue;
        }


        public static void ShowDayTime(string daytime)
            => Console.WriteLine(daytime);
    }
}