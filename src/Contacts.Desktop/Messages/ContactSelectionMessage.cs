using CommunityToolkit.Mvvm.Messaging.Messages;
using Contacts.Core.Models;

namespace Contacts.Desktop.Messages;

public class ContactSelectionMessage : ValueChangedMessage<Contact>
{
    public ContactSelectionMessage(Contact contact) : base(contact)
    {
    }
}