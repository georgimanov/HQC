namespace Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    internal class PhonebookEntry
    {
        private const string Code = "+359";
        private static readonly IPhonebookRepository Data = new PhonebookRepository();
        public static StringBuilder Input = new StringBuilder();

        private static void Main()
        {
            while (true)
            {
                var readLine = Console.ReadLine();
                if (readLine == "End" || readLine == null)
                {
                    break;
                }

                var beginReading = readLine.IndexOf('(');

                if (beginReading == -1)
                {
                    Console.WriteLine("error!");
                    Environment.Exit(0);
                }

                var userInput = readLine.Substring(0, beginReading);
                if (!readLine.EndsWith(")"))
                {
                    throw new ArgumentException("Invalid input");
                }

                var s = readLine.Substring(beginReading + 1, readLine.Length - beginReading - 2);
                var strings = s.Split(',');
                for (var j = 0; j < strings.Length; j++)
                {
                    strings[j] = strings[j].Trim();
                }

                if ((userInput.StartsWith("AddPhone")) && (strings.Length >= 2))
                {
                    ParseCommand("AddPhone", strings);
                }
                else if ((userInput == "ChangePhone") && (strings.Length == 2))
                {
                    ParseCommand("ChangePhone", strings);
                }
                else if ((userInput == "List") && (strings.Length == 2))
                {
                    ParseCommand("ListPhones", strings);
                }
                else
                {
                    throw new StackOverflowException();
                }
            }

            Console.Write(Input);
        }

        public static void ParseCommand(string command, string[] phoneEntries)
        {
            if (command == "AddPhone")
            {
                var name = phoneEntries[0];
                var phoneNumbers = phoneEntries.Skip(1).ToList();
                for (var i = 0; i < phoneNumbers.Count; i++)
                {
                    phoneNumbers[i] = Conv(phoneNumbers[i]);
                }

                var phoneAdded = Data.AddPhone(name, phoneNumbers);
                if (phoneAdded)
                {
                    Print("Phone entry created");
                }
                else
                {
                    Print("Phone entry merged");
                }
            }
            else if (command == "ChangePhone")
            {
                Print("" + Data.ChangePhone(Conv(phoneEntries[0]), Conv(phoneEntries[1])) + " numbers changed");
            }
            else if (command == "ListPhones")
            {
                try
                {
                    IEnumerable<ListPhones> entries = Data.ListEntries(int.Parse(phoneEntries[0]), int.Parse(phoneEntries[1]));
                    foreach (var entry in entries)
                    {
                        Print(entry.ToString());
                    }
                }
                catch (Exception)
                {
                    Print("Invalid range");
                }
            }
        }

        private static string Conv(string num)
        {
            var sb = new StringBuilder();
            for (var i = 0; i <= Input.Length; i++)
            {
                sb.Clear();
                foreach (var ch in num)
                {
                    if (char.IsDigit(ch) || (ch == '+'))
                    {
                        sb.Append(ch);
                    }
                }

                if (sb.Length >= 2 && sb[0] == '0' && sb[1] == '0')
                {
                    sb.Remove(0, 1);
                    sb[0] = '+';
                }

                while (sb.Length > 0 && sb[0] == '0')
                {
                    sb.Remove(0, 1);
                }

                if (sb.Length > 0 && sb[0] != '+')
                {
                    sb.Insert(0, Code);
                }

                sb.Clear();
                foreach (var ch in num)
                {
                    if (char.IsDigit(ch) || (ch == '+'))
                    {
                        sb.Append(ch);
                    }
                }

                if (sb.Length >= 2 && sb[0] == '0' && sb[1] == '0')
                {
                    sb.Remove(0, 1);
                    sb[0] = '+';
                }

                while (sb.Length > 0 && sb[0] == '0')
                {
                    sb.Remove(0, 1);
                }

                if (sb.Length > 0 && sb[0] != '+')
                {
                    sb.Insert(0, Code);
                }

                sb.Clear();
                foreach (var ch in num)
                {
                    if (char.IsDigit(ch) || (ch == '+'))
                    {
                        sb.Append(ch);
                    }
                }

                if (sb.Length >= 2 && sb[0] == '0' && sb[1] == '0')
                {
                    sb.Remove(0, 1);
                    sb[0] = '+';
                }

                while (sb.Length > 0 && sb[0] == '0')
                {
                    sb.Remove(0, 1);
                }

                if (sb.Length > 0 && sb[0] != '+')
                {
                    sb.Insert(0, Code);
                }
            }

            return sb.ToString();
        }

        private static void Print(string text)
        {
            Input.AppendLine(text);
        }
    }
}