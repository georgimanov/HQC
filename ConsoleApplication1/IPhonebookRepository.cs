namespace Phonebook
{
    using System.Collections.Generic;

    internal interface IPhonebookRepository
    {
        bool AddPhone(string name, IEnumerable<string> phoneNumbers);

        int ChangePhone(string oldPhoneNumber, string newPhoneNumber);

        ListPhones[] ListEntries(int startIndex, int count);
    }
}