using System.Collections.Generic;
using System.Linq;

namespace HashTable
{
    public class HashTable<K, V>
    {
        public class Entry
        {
            public K Key { get; private set; }
            public V Value { get; private set; }

            public Entry(K key, V value)
            {
                Key = key;
                this.Value = value;
            }

            public override bool Equals(object obj)
            {
                var rhs = obj as Entry;
                if (rhs != null)
                    return Key.Equals(rhs.Key);
                return false;
            }
        }

        public LinkedList<V> InsertionOrder { get; private set; }
        public int Count { get; private set; }
        public int Size { get; private set; }

        private List<Entry>[] table;

        public HashTable(int size = 10)
        {
            this.Size = size;
            this.InsertionOrder = new LinkedList<V>();
            this.table = new List<Entry>[size];

            for (int i = 0; i < size; i++)
                table[i] = new List<Entry>();

        }        public void Put(K key, V value)
        {
            int hashIndex = HashIndex(key);
            var newEntry = new Entry(key, value);
            table[hashIndex].Add(newEntry);

            InsertionOrder.AddLast(newEntry.Value);
            ++Count;
        }        public bool Remove(K key)
        {
            if (!Contains(key))
                return false;

            int hashIndex = HashIndex(key);

            var entry = table[hashIndex].SingleOrDefault(x => x.Key.Equals(key));
            InsertionOrder.Remove(entry.Value);

            // Remove it from the table
            table[hashIndex].Remove(entry);

            --Count;

            return true;
        }        public V Get(K key)
        {
            int hashIndex = HashIndex(key); //←-----Räkna ut nyckels index
            if (Contains(key))
            {
                //←----Kontrollera om nyckeln finns
                var entry = table[hashIndex].SingleOrDefault(x => x.Key.Equals(key)); // < ---Hitta nyckeln
                return entry.Value; //< ----returnera värdet
            }
            return default(V); // Test me with ints
        }        public bool Contains(K key)
        {
            int hashIndex = HashIndex(key);
            return table[hashIndex].Any(x => x.Key.Equals(key));
        }
        private int HashIndex(K key)
        {
            int hashCode = key.GetHashCode();
            hashCode = hashCode % table.Length;
            return (hashCode < 0) ? -hashCode : hashCode;
        }


    }
}
