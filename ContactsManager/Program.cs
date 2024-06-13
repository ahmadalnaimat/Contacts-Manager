using System;
using System.Collections.Generic;

namespace ContactsManager
{
    public class Program
    {
        public static List<string> ContactList = new List<string>();

        static void Main(string[] args)
        {
            ContactsManager();
        }

        public static void ContactsManager()
        {
            while (true)
            {
                Console.WriteLine("1. Add Contact \n2. Remove Contact \n3. View All Contacts \n4. Exit\n");
                string opp = Console.ReadLine();
                switch (opp)
                {
                    case "1":
                        Console.WriteLine("Enter contact name:");
                        string addContactName = Console.ReadLine();
                        AddContact(addContactName);
                        DisplayContactList();
                        break;
                    case "2":
                        Console.WriteLine("Enter contact name to remove:");
                        string removeContactName = Console.ReadLine();
                        RemoveContact(removeContactName);
                        DisplayContactList();
                        break;
                    case "3":
                        ViewAllContacts();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        public static List<string> AddContact(string contactName)
        {
            if (string.IsNullOrWhiteSpace(contactName))
            {
                Console.WriteLine("Cannot add an empty contact.\n");
                return new List<string>(ContactList);
            }

            if (ContactList.Contains(contactName))
            {
                Console.WriteLine("Contact already exists.\n");
            }
            else
            {
                ContactList.Add(contactName);
                Console.WriteLine("Contact added successfully.\n");
            }

            return new List<string>(ContactList);
        }

        public static List<string> RemoveContact(string contactName)
        {
            if (ContactList.Remove(contactName))
            {
                Console.WriteLine("Contact removed successfully.\n");
            }
            else
            {
                Console.WriteLine("Contact not found.\n");
            }

            return new List<string>(ContactList);
        }

        public static List<string> ViewAllContacts()
        {
            DisplayContactList();
            return new List<string>(ContactList);
        }

        private static void DisplayContactList()
        {
            if (ContactList.Count == 0)
            {
                Console.WriteLine("No contacts found.\n");
            }
            else
            {
                Console.WriteLine("Contact List:");
                foreach (string contact in ContactList)
                {
                    Console.WriteLine(contact);
                }
            }
        }
    }
}
