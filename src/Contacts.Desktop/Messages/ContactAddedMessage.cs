using CommunityToolkit.Mvvm.Messaging.Messages;
using Contacts.Core.Models;

namespace Contacts.Desktop.Messages;

public class ContactAddedMessage : ValueChangedMessage<Contact>
{
    public ContactAddedMessage(Contact value) : base(value)
    {
    }
}