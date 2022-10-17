using System;

namespace RecordSample
{
    internal class Program
    {

        //Use Cases von Records 
        
        //- Ergebnisse von einem Service kann man in einem Record speichern. Mit dem Vorteil, dass das Ergebnis nicht veränderbar ist
        //- EF Core könnte mit Records arbeiten  -> ChangeTracker kann Records 
        //- MediatR -> Records für Commands / Request -> Commands und Request sind Klassen ohne Methode etc... 


        //- Domain Driven Development -> Value Objects -> Wie stelle eine Währung da


        //NO Go: Records werden nicht mit dem Builder-Pattern verwendet -> Builder Pattern ist ausgelget ein Object 
        static void Main(string[] args)
        {
            //Records
            PersonRecord personRecord1 = new PersonRecord(1, "Helge Schneider");
            //personRecord.Name = "Helga";     -> Id und Name sind jeweils INIT-Properties
            
            PersonRecord personRecord2 = new PersonRecord(1, "Helge Schneider");


            //Klassen
            PersonClass personClass1 = new PersonClass(1, "Harry Weinfurt");
            PersonClass personClass2 = new PersonClass(1, "Harry Weinfurt");


            // Records vs. Class  -> == Operator UND Equals 

            #region == Operator
            //Bei Referenztypen werden die Speicheradresse verglichen
            if (personClass1 == personClass2)
               Console.WriteLine("gleich");
            else
                Console.WriteLine("ungleich");


            //Bei Records 
            if (personRecord1 == personRecord2)
                Console.WriteLine("gleich");
            else
                Console.WriteLine("ungleich");

            #endregion

            #region Equals 

            if (personClass1.Equals(personClass2))
                Console.WriteLine("gleich");
            else
                Console.WriteLine("ungleich");


            if (personRecord1.Equals(personRecord2))
                Console.WriteLine("gleich");
            else
                Console.WriteLine("ungleich");
            #endregion


            #region Was ist ein Deconstructor

            //Deconstrutor - Methode wird uns nur generiert, wenn PersonRecord in dieser kompakten Form definiert ist:
            //-> public record PersonRecord(int Id, string Name);

            (int id2, string name2) = personRecord1; //Die Methode Deconstruct wird automatisch aufgerufen. 


            EmployeeRecord employeeRecord = new EmployeeRecord(1, "Otto Walkes");

            //(int id1, string name1) = employeeRecord;
            //(_, string name1) = employeeRecord -> Name wird zurück gegeben 
            #endregion


            #region Wie kann man trotzdem Werte verändern? Geht das überhaupt?
            Person person1 = new("Nancy", "Davolio") { PhoneNumbers = new string[2] { "1234", "5678" } };


            //Hier befinden wir uns in der Konstruktion von person2 
            Person person2 = person1 with { FirstName = "John" };

            Console.WriteLine(  person2.FirstName); //John 
            #endregion

        }
    }

    public record PersonRecord(int Id, string Name);

    public class PersonClass
    {
        public PersonClass(int id, string name )
        {
            this.Id = id;
            this.Name = name;
        }

        public int Id { get; set; } 
        public string Name { get; set; }    
    }


    public record EmployeeRecord
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public EmployeeRecord(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }


        //Wo ist Deconstructor? 
    }


    #region Vererbung
    public record Animal(int Id, string Name, DateTime Birthday);

    public record Dog (string HundegattungName,  string Name, int Id, DateTime Birthday) 
        : Animal (Id,  Name,  Birthday);
    #endregion



    public record Person(string FirstName, string LastName)
    {
        //Nicht vergessen FirstName und LastName {get;init}
        public string[] PhoneNumbers { get; init; }
    }


}