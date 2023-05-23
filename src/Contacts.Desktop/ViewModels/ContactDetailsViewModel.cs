using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using Contacts.Core.Models;
using Contacts.Desktop.Messages;

namespace Contacts.Desktop.ViewModels;

public partial class ContactDetailsViewModel : ViewModelBase,
    IRecipient<ContactSelectionMessage>
{
    public ContactDetailsViewModel()
    {
        WeakReferenceMessenger.Default.RegisterAll(this);
    }
    
    [ObservableProperty]
    private Contact? _contact;

    public void Receive(ContactSelectionMessage message)
    {
        Contact = message.Value;
    }
}