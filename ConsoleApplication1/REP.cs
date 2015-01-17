namespace Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;
    internal class REP : IPhonebookRepository
    {
        private OrderedSet<ListPhones> sorted = new OrderedSet<ListPhones>();

        private Dictionary<string, ListPhones> dict = new Dictionary<string, ListPhones>();

        private MultiDictionary<string, ListPhones> multidict = new MultiDictionary<string, ListPhones>(false);

        public bool AddPhone(string name, IEnumerable<string> nums)
        {
            string name2 = name.ToLowerInvariant();
            ListPhones entry;
            bool flag = !dict.TryGetValue(name2, out entry);
            if (flag)
            {
                entry = new ListPhones();
                entry.Name = name;
                entry.PhonenumberSortedSet = new SortedSet<string>();
                dict.Add(name2, entry);
                sorted.Add(entry);
            }

            foreach (var num in nums)
            {
                multidict.Add(num, entry);
            }

            entry.PhonenumberSortedSet.UnionWith(nums);

            return flag;
        }

        public int ChangePhone(string oldent, string newent)
        {
            var found = multidict[oldent].ToList();
            foreach (var entry in found)
            {
                entry.PhonenumberSortedSet.Remove(oldent);
                multidict.Remove(oldent, entry);
                entry.PhonenumberSortedSet.Add(newent);
                multidict.Add(newent, entry);
            }

            return found.Count;
        }

        public ListPhones[] ListEntries(int first, int num)
        {
            if (first < 0 || first + num > dict.Count)
            {
                Console.WriteLine("Invalid start index or count.");

                return null;
            }

            ListPhones[] list = new ListPhones[num];

            for (int i = first; i <= first + num - 1; i++)
            {
                ListPhones entry = sorted[i];
                list[i - first] = entry;
            }

            return list;
        }
    }
}