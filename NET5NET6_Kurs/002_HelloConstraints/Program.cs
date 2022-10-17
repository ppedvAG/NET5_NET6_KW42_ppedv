using System.Collections;

namespace _002_HelloConstraints
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ////DataStore<T> where T : class

            DataStore<string> store1 = new DataStore<string>();
            DataStore<MyClass> store2 = new DataStore<MyClass>();
            DataStore<IMyInterface> store3 = new DataStore<IMyInterface>();
            //DataStore<MyStruct> store4 = new DataStore<MyStruct>();
            //DataStore<int> store5 = new DataStore<int>();
            DataStore<ArrayList> store6 = new DataStore<ArrayList>();
            DataStore<MyRecord> store7 = new DataStore<MyRecord>();

            //Übung 2 hätte das Gegenteilige Ergebniss 
            ////DataStore1<T> where T : struct 
            //DataStore1<string> store7 = new DataStore1<string>();
            //DataStore1<MyClass> store8 = new DataStore1<MyClass>();
            //DataStore1<IMyInterface> store9 = new DataStore1<IMyInterface>();
            //DataStore1<MyStruct> store10 = new DataStore1<MyStruct>();
            //DataStore1<int> store11 = new DataStore1<int>();
            //DataStore1<MyRecord> store7 = new DataStore1<MyRecord>();
        }
    }



















    //In T dürfen nur Referenztypen (Klasse, Interfaces, string, List<T>,  .... )
    public class DataStore<T> where T : class
    {
    }

    //In T dürfen nur Wertettypen (Structs, Enums, int, float, bool, double, chars ) 
    public class DataStore1<T> where T : struct
    {

    }
    // In T dürfen nur Animal oder abgeleitete Klasse von Animal (Vererbungsbaum) 
    public class DataStore2<T> where T : Animal
    {

    }

    //Hier dürfen nur Objekte, die einen Default-Konstruktor beinhalten
    public class DataStore3<T> where T : new()
    {

    }



    public class Animal
    {
        //ctor
        public Animal() //<- Default-Konstruktor
        {
            //hier darf stehen 
        }
        public string Name { get; set; } = "R2D2";
    }

    public class Dog : Animal
    {
        public string Hunderasse { get; set; } = "ein wau wau";
    }

    public record MyRecord
    {

    }
    public class MyClass
    {

    }

    public interface IMyInterface
    {
    }

    public struct MyStruct
    {
        string Name { get; set; }
    }

    public class MyDictionary<TKey, TItem> where TKey : struct
    {
        public void Add(TKey key, TItem item)
        {
            //...
        }

        public TItem GetByKey(TKey key)
        {
            // 

            return default(TItem);
        }

        public void DataTypeOftheYear<DataType>(DataType theType)
        {
        }
    }


    public interface IGenericInterface<T> where T : class
    {

    }
}