using Contacts.Core.Interfaces;
using Contacts.Core.Models;

namespace Contacts.Services;

public class ContactsService : IContactsService
{
    private static readonly List<Contact> ContactsList = new() 
    {
        new Contact(Guid.NewGuid(), "Demir Gala", "1234567890", "example1@example.com"),
        new Contact(Guid.NewGuid(), "Loretta Hoder", "1234567891", "example2@example.com"),
        new Contact(Guid.NewGuid(), "Norbu Anan", "1234567892", "example3@example.com"),
        new Contact(Guid.NewGuid(), "James Smith", "1234567892", "example3@example.com"),
        new Contact(Guid.NewGuid(), "Alex Anan", "1234567892", "example3@example.com"),
    };

    public void Add(Contact contact) => ContactsList.Add(contact);

    public IEnumerable<Contact> GetContacts() => ContactsList;
}