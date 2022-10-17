using System;

namespace ValueTypesVsReferenceTypes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Was ist ein Wertetyp?:

            //Welche Datentypen:
            //bool, short, int, long, decimal, float, double.... 
            //struct

            //Was ist ein Referenztyp?:

            //Welche Datentypen
            //string, class, interfaces, records



            SPerson sPerson = new SPerson()
            {
                Name = "Peter",
                Alter = 30
            };

            CPerson cPerson = new CPerson()
            {
                Name = "Peter",
                Alter = 30
            };

            AlternSPerson(sPerson);
            AlternCPerson(cPerson);

            Console.WriteLine(sPerson.Alter);
            Console.WriteLine(cPerson.Alter);
        }


        //AlternSPerson(SPerson person)  -> SPerson person reserviert Arbeitsspeicher und erhält die WERTE bei der Übergabe
        public static void AlternSPerson(SPerson person) 
            => person.Alter++;

        public static void AlternCPerson(CPerson person) //Speicheradresse wird übergeben->Daher ist auf Peter um 1 Jahr gealtert 
            => person.Alter++;
    }


    //Wertetyp 
    public struct SPerson
    {
        public string Name { get; set; }
        public int Alter { get; set; }

        
    }

    //Referencetype 
    public class CPerson
    {
        public string Name { get; set; }
        public int Alter { get; set; }
    }
}