namespace Contacts.Desktop.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ViewModelBase ContactsListViewModel { get; set; } = new ContactsListViewModel();
}