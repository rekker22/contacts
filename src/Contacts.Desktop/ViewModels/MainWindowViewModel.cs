using CommunityToolkit.Mvvm.ComponentModel;
using Contacts.Desktop.Models;

namespace Contacts.Desktop.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public ViewModelBase ContactsListViewModel { get; init; }
    public ViewModelBase ContactDetailsViewModel { get; init; }

    public MainWindowViewModel()
    {
        ContactsListViewModel = new ContactsListViewModel();
        ContactDetailsViewModel = new ContactDetailsViewModel();
        SelectedContact = null;
    }

    [ObservableProperty]
    private Contact? _selectedContact;
}