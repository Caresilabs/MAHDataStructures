/*
    Simon Bothén
    DA304A HT15
*/
using System.Collections.Generic;
using System.Linq;

namespace HashTable
{
    /// ===========================================
    /// NOTE FOR TEACHER: I used "table[hashIndex].SingleOrDefault(x => x.Key.Equals(key));" instead of your suggestion
    /// "table[hashIndex].Find(new Entry(key, null))" because this skips the unnecessary allocation and no override is needed for @Entry::Equals().
    /// 
    /// Cheers!
    /// ===========================================

    /// <summary>
    /// A HashTable is a fast way of accessing data. Simply map a key to a value and use @Get(Key) to retrieve it.
    /// Be sure to set a appropriate size or else you will loose performance and then it's recommended to use something else than a HashTable.
    /// </summary>
    /// <typeparam name="K">Key</typeparam>
    /// <typeparam name="V">Value</typeparam>
    public class HashTable<K, V>
    {
        public class Entry
        {
            /// <summary>
            /// The Key of type K. 
            /// </summary>
            public K Key { get; private set; }

            /// <summary>
            /// The value that is stored the the Keys position in the HashTable.
            /// </summary>
            public V Value { get; internal set; }

            public Entry(K key, V value)
            {
                Key = key;
                this.Value = value;
            }
        }

        /// <summary>
        /// A LinkedList of the objects inserted in order.
        /// </summary>
        public LinkedList<V> InsertionOrder { get; private set; }

        /// <summary>
        /// How many objects are in the HashTable? Ask this mate kindly and you will know.
        /// </summary>
        public int Count { get { return InsertionOrder.Count; } }


        /// <summary>
        /// The actual table the Key,Value pair are stored.
        /// </summary>
        private LinkedList<Entry>[] table;

        /// <summary>
        /// Creates a new HashTable
        /// </summary>
        /// <param name="size">The size of the table. Please choose this one carefully!</param>
        public HashTable(int size = 10)
        {
            this.InsertionOrder = new LinkedList<V>();
            this.table = new LinkedList<Entry>[size];

            for (int i = 0; i < size; i++)
                table[i] = new LinkedList<Entry>();

        }

        /// <summary>
        /// Put a Value in the hashtable with the Key. If the key already exists then we change it with input value
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="value">The value to store in the HashTable</param>
        public void Put(K key, V value)
        {
            int hashIndex = HashIndex(key);

            // If the key is not in the HashTable then we add it, else we change it
            if (!Contains(key))
            {
                var newEntry = new Entry(key, value);
                table[hashIndex].AddLast(newEntry);
                InsertionOrder.AddLast(newEntry.Value);
            }
            else
            {
                table[hashIndex].SingleOrDefault().Value = value;
            }
        }

        /// <summary>
        /// Removes the value that is stored with the key.
        /// </summary>
        /// <returns>If it exist and was deleted</returns>
        public bool Remove(K key)
        {
            if (!Contains(key))
                return false;

            int hashIndex = HashIndex(key);

            var entry = table[hashIndex].SingleOrDefault(x => x.Key.Equals(key));
            InsertionOrder.Remove(entry.Value);

            // Remove it from the table
            table[hashIndex].Remove(entry);

            return true;
        }

        /// <summary>
        /// Finds the value that matches the key. OBS! if it is not found it will return default(V). So if you use value types such as int be sure to
        /// call @Contains() before or else you will get an 0 as return;
        /// </summary>
        /// <returns>The value that was found with the key</returns>
        public V Get(K key)
        {
            int hashIndex = HashIndex(key);
            if (Contains(key))
            {
                var entry = table[hashIndex].SingleOrDefault(x => x.Key.Equals(key));
                return entry.Value;
            }
            return default(V);
        }

        /// <summary>
        /// Does this HashTable contains a value that matches the input key? I don't know but this function sure do.
        /// </summary>
        /// <returns>If there is a value that matches the key</returns>
        public bool Contains(K key)
        {
            int hashIndex = HashIndex(key);
            return table[hashIndex].Any(x => x.Key.Equals(key));
        }

        /// <summary>
        /// Returns the max size of the any of the lists in the table.
        /// </summary>
        /// <returns></returns>
        public int GetMaxCurrentPositionCollisions()
        {
            return table.Max(x => x.Count);
        }

        /// <summary>
        /// A simlpe private HashFunction that converts a hashCode to a position in the hash array;
        /// </summary>
        /// <returns>A capped hash to fit the table size</returns>
        private int HashIndex(K key)
        {
            int hashCode = key.GetHashCode();
            hashCode = hashCode % table.Length;
            return (hashCode < 0) ? -hashCode : hashCode;
        }
    }
}
