using CommunityToolkit.Mvvm.Messaging.Messages;
using Contacts.Desktop.Models;

namespace Contacts.Desktop.Messages;

public class SelectedContactChangeMessage : ValueChangedMessage<Contact>
{
    public SelectedContactChangeMessage(Contact contact) : base(contact)
    {
    }
}