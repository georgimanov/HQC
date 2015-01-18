namespace Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;
    internal class PhonebookRepository : IPhonebookRepository
    {
        private OrderedSet<ListPhones> sorted = new OrderedSet<ListPhones>();

        private Dictionary<string, ListPhones> dict = new Dictionary<string, ListPhones>();

        private MultiDictionary<string, ListPhones> multidict = new MultiDictionary<string, ListPhones>(false);

        public bool AddPhone(string name, IEnumerable<string> nums)
        {
            string personName = name.ToLowerInvariant();
            ListPhones listPhones;
            bool flag = !dict.TryGetValue(personName, out listPhones);
            if (flag)
            {
                listPhones = new ListPhones();
                listPhones.FirstName = name;
                listPhones.PhonenumberSortedSet = new SortedSet<string>();
                dict.Add(personName, listPhones);
                sorted.Add(listPhones);
            }

            foreach (var num in nums)
            {
                multidict.Add(num, listPhones);
            }

            listPhones.PhonenumberSortedSet.UnionWith(nums);

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
                throw  new ArgumentOutOfRangeException("Invalid start index or count.");
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