using System;

namespace HelloGenerics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Was sind generische Methoden

            //Diese List beinhaltet Strings -> typsierter Liste 
            IList<string> cityNames = new List<string>();

            cityNames.Add("Berlin");
            cityNames.Add("London");
            cityNames.Add("Sydney");
            #endregion

            #region Dictionary 
            //Key/Value
            Dictionary<int, string> dictPersonen = new Dictionary<int, string>();

            /* Implementierung .NET 4.8 -> Dictionary -> eine Add-Methode ist Privat
             *  
             * void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> keyValuePair) {
                    Add(keyValuePair.Key, keyValuePair.Value);
                }
             * 
             * 
             * 
             * 
             */

            dictPersonen.Add(1, "Hannes");
            dictPersonen.Add(2, "Andre");

            if (!dictPersonen.ContainsKey(3))
                dictPersonen.Add(3, "Kevin");

            //Durchlauf eines Dictionary mit KeyValue

            foreach(KeyValuePair<int, string> currentEntry in dictPersonen)
            {
                Console.WriteLine(currentEntry.Key);
                Console.WriteLine(currentEntry.Value);
            }
            #endregion

            #region IDictionary kann 2 überladene Add-Methoden 
            //Beim verwenden des Interface, habe ich 2 überlagerte Add-Methoden drin 
            IDictionary<int, string> dict = new Dictionary<int, string>();


            dict.Add(1, "Otto Walkes");
            dict.Add(new KeyValuePair<int, string>(2, "Harry Weinfurt"));

            #endregion
        }
    }



    public class DataStore <T>
    {
        private T[] _data = new T[10];

        public T[] Data
        {
            get { return _data; }
            set { _data = value; }
        }


        public void AddOrUpdate(int index, T item)
        {
            if (index >= 0 && index < 10)
            {
                _data[index] = item;
            }
            else
                throw new IndexOutOfRangeException();
        }

        public T GetByIndex(int index)
        {
            if (index >= 0 && index < 10)
            {
                return _data[index];
            }
            else
                throw new IndexOutOfRangeException();
        }

        //Generische Methode 
        public MyType GenerischeMethode<MyType>()

        {
            MyType variable = default!;
            return variable;
        }


        //Generische Methode mit Constraints
        public MyType GenerischeMethode2<MyType>()
            where MyType : class //Referenztypen dürfen nur verwendet werden 

        {
            MyType variable = default!;
            return variable;
        }

    }
}