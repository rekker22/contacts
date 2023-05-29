using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Contacts.Desktop.Messages;

namespace Contacts.Desktop.ViewModels;

public partial class MainWindowViewModel : ViewModelBase,
    IRecipient<ContactAddedMessage>
{
    [ObservableProperty] 
    private ViewModelBase _leftContentViewModelBase;

    [ObservableProperty] 
    private ViewModelBase _rightContentViewModel;

    public MainWindowViewModel()
    {
        LeftContentViewModelBase = new ContactsListViewModel();
        RightContentViewModel = new ContactDetailsViewModel();
        IsActive = true;
    }

    [RelayCommand]
    private void AddNewContact() => RightContentViewModel = new AddContactViewModel();

    public void Receive(ContactAddedMessage message) => RightContentViewModel = new ContactDetailsViewModel();
}