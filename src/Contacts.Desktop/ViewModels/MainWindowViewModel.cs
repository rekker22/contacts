namespace Contacts.Desktop.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ViewModelBase ContactsListViewModel { get; init; }
    public ViewModelBase ContactDetailsViewModel { get; init; }

    public MainWindowViewModel()
    {
        ContactsListViewModel = new ContactsListViewModel();
        ContactDetailsViewModel = new ContactDetailsViewModel();
    }
}