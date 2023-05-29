using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Contacts.Desktop.Views;

public partial class AddContactView : UserControl
{
    public AddContactView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}