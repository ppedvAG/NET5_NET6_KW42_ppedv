namespace _007_ContinueWithParams
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Task<string> t1 = Task.Run(Daytime);

            //Wenn die Methode DayTime fertig ist,
            //Übergeben wir von t1.Result, das Ergebnis an die Methode ShowDayTime 
            await t1.ContinueWith(t => ShowDayTime(t.Result));

            //Variante
            //Task t2 = t1.ContinueWith(t => ShowDayTime(t1.Result)); -> Wenn zuerst ShowDayTime aufrufen wollen und DANACH TranslateDayTime
            //t2.ContinueWith<string>(t => TranslateDayTime(t1.Result));

            Task<string> translateTask = t1.ContinueWith<string>(t => TranslateDayTime(t1.Result));
            await translateTask.ContinueWith(t => ShowDayTime(translateTask.Result));

            Console.ReadLine();
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


        public static async Task ShowDayTime(string daytime)
        {
            await Task.Delay(1000);
            Console.WriteLine(daytime);
        }
            


    }
}