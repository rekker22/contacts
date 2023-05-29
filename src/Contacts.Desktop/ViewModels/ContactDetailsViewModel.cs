using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using Contacts.Core.Models;

namespace Contacts.Desktop.ViewModels;

public partial class ContactDetailsViewModel : ViewModelBase,
    IRecipient<PropertyChangedMessage<Contact>>
{
    public ContactDetailsViewModel()
    {
        IsActive = true;
    }
    
    [ObservableProperty]
    private Contact? _contact;

    public void Receive(PropertyChangedMessage<Contact> message) => Contact = message.NewValue;
}