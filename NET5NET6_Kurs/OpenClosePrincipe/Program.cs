namespace OpenClosePrincipe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }


    public class Employee
    {
        //Datenstruktur 
        public int Id { get; set; }
        public string Name { get; set; }
    }

    #region Bad-Code
    public class BadReportGenerator
    {
        public int ReportType { get; set; }

        //Methode Generate wird zu von Code-Zeilen zu groß
        //Jedes Produkt (PDF, CR, LL) hat nur ein if {...}
        public void Generate(Employee emp)
        {
            //PDF -> Wir verwenden dafür eine PDF.dll (Watermark / Signaturen / CompressRate) 
            if (ReportType == 1)
            {
                Console.WriteLine("PDF wird erstellt"); 
            }
            else if (ReportType == 2) //Crystal Reports -> Dll Verwenden (Templates, Watermark)
            {
                Console.WriteLine("CR wird erstellt"); 
            }
            else if (ReportType == 3) //CSV 2022 Version -> 
            {
                Console.WriteLine("CSV wird erstellt");
            }
            else if (ReportType == 3) //List & Label 10 -> dll wird verwendet -> Dll Verwenden (Templates, Signaturen)
            {
                Console.WriteLine("CR wird erstellt");

                
            }
        }
    }
    #endregion

    #region Variante 1 - Mit abstrakter Klasse 

    //Open - Part
    public abstract class ReportGeneratorBase
    {
        public abstract void Generate(Employee emp);

        protected void Methode1 ()
        {
            Console.WriteLine("Mache etwas, was alle vererbte Klasse auch verwenden");
        }
    }


    //Close-Part
    public class PDFReportGenerator : ReportGeneratorBase
    {
        //Properties 
        
        public override void Generate(Employee emp)
        {
           //Ein PDF Report wird erstellt 
        }
    }

    public class CRReportGenerator : ReportGeneratorBase
    {
        public override void Generate(Employee emp)
        {
            //Ein CR Report wird erstellt 
        }
    }

    #endregion

    #region Variante 2 - Mit Interface


    //Open-Part -> Beispiel Builder-Design Pattern 
    public interface IReportGenerator
    {
        //virtual/abstract usw. -> In wie Weit beeinflusst das die Design-Pattern Diskussion
        void Generate(Employee emp);


        DateTime GetCurrentTime()
        {
            return DateTime.Now;
        }

    }


    //Close-Part
    public class PDFGenerator2 : IReportGenerator
    {
        public void Generate(Employee emp)
        {
            //Ein PDF Report wird erstellt 
        }
    }


    #endregion
}