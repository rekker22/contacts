using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Contacts.Desktop.Views;

public partial class ContactDetailsView : UserControl
{
    public ContactDetailsView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}