using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Contacts.Desktop.Views;

public partial class ContactsListView : UserControl
{
    public ContactsListView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}