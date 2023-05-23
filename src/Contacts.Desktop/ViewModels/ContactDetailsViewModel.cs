using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using Contacts.Desktop.Messages;
using Contacts.Desktop.Models;

namespace Contacts.Desktop.ViewModels;

public partial class ContactDetailsViewModel : ViewModelBase,
    IRecipient<SelectedContactChangeMessage>
{
    public ContactDetailsViewModel()
    {
        WeakReferenceMessenger.Default.RegisterAll(this);
    }
    
    [ObservableProperty]
    private Contact? _contact;

    public void Receive(SelectedContactChangeMessage message)
    {
        Contact = message.Value;
    }
}