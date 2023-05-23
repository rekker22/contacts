using Contacts.Core.Models;

namespace Contacts.Core.Interfaces;

public interface IContactsService
{
    void Add(Contact contact);
    IEnumerable<Contact> GetContacts();
}