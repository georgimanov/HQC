using System;
using System.Collections.Generic;
using System.Text;

namespace Phonebook
{
    internal class ListPhones : IComparable<ListPhones>
    {
        private string name;
        private string name2;

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
                name2 = value.ToLowerInvariant();
            }
        }

        public SortedSet<string> PhonenumberSortedSet;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            
            sb.Clear();
            sb.Append('[');
            sb.Append(Name);
            bool flag = true;
            foreach (var phone in PhonenumberSortedSet)
            {
                if (flag)
                {
                    sb.Append(": ");
                    flag = false;
                }
                else
                {
                    sb.Append(", ");
                }

                sb.Append(phone);
            }

            sb.Append(']');
            
            return sb.ToString();
        }

        public int CompareTo(ListPhones other)
        {
            return name2.CompareTo(other.name2);
        }
    }
}