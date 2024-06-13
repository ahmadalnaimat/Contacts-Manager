using System.Collections.Generic;
using ContactsManager;
using Xunit;

namespace ContactsManager.Tests
{
    public class ContactsManagerTests
    {
        public ContactsManagerTests()
        {
            Program.ContactList.Clear();
        }

        [Fact]
        public void AddContact_AddsNewContactToList()
        {
            string newContact = "ahmad";

            var updatedList = Program.AddContact(newContact);

            Assert.Contains(newContact, updatedList);
        }

        [Fact]
        public void AddContact_DoesNotAddDuplicateContact()
        {
            string newContact = "ahmad";
            Program.AddContact(newContact);

            var updatedList = Program.AddContact(newContact);

            var expectedList = new List<string> { newContact };
            Assert.Equal(expectedList, updatedList);
        }

        [Fact]
        public void RemoveContact_RemovesContactFromList()
        {
            string contactToRemove = "ahmad";
            Program.AddContact(contactToRemove);

            var updatedList = Program.RemoveContact(contactToRemove);

            Assert.DoesNotContain(contactToRemove, updatedList);
        }

        [Fact]
        public void ViewAllContacts_ReturnsAllContacts()
        {
            var contactList = new List<string> { "Dave", "Eve" };
            foreach (var contact in contactList)
            {
                Program.AddContact(contact);
            }

            var retrievedList = Program.ViewAllContacts();

            Assert.Equal(contactList, retrievedList);
        }
    }
}
