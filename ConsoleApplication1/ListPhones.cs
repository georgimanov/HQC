using System;
using System.Collections.Generic;
using System.Text;

namespace Phonebook
{
    internal class ListPhones : IComparable<ListPhones>
    {
        private string firstName;
        private string secodName;

        public string FirstName
        {
            get
            {
                return firstName;
            }

            set
            {
                firstName = value;
                secodName = value.ToLowerInvariant();
            }
        }

        public SortedSet<string> PhonenumberSortedSet;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            
            sb.Clear();
            sb.Append('[');
            sb.Append(FirstName);
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
            return secodName.CompareTo(other.secodName);
        }
    }
}