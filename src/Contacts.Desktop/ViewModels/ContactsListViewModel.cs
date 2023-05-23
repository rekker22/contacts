using System;
using System.Collections.Generic;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using Contacts.Desktop.Messages;
using Contacts.Desktop.Models;

namespace Contacts.Desktop.ViewModels;

public partial class ContactsListViewModel : ViewModelBase
{
    public ContactsListViewModel()
    {
        _contacts = new List<Contact>
        {
            new Contact(Guid.NewGuid(), "Demir Gala", "1234567890", "example1@example.com"),
            new Contact(Guid.NewGuid(), "Loretta Hoder", "1234567891", "example2@example.com"),
            new Contact(Guid.NewGuid(), "Norbu Anan", "1234567892", "example3@example.com"),
            new Contact(Guid.NewGuid(), "James Smith", "1234567892", "example3@example.com"),
            new Contact(Guid.NewGuid(), "Alex Anan", "1234567892", "example3@example.com"),
        };
        _searchText = "";
        FilteredContactsList = _contacts;
    }

    private readonly List<Contact> _contacts;

    [ObservableProperty] 
    private List<Contact> _filteredContactsList;

    private Contact? _selectedContact;
    public Contact? SelectedContact
    {
        get => _selectedContact;
        set
        {
            if (SetProperty(ref _selectedContact, value) && _selectedContact is not null)
            {
                WeakReferenceMessenger.Default.Send(new SelectedContactChangeMessage(_selectedContact));
            }
        }
    }

    private string _searchText;
    public string SearchText
    {
        get => _searchText;
        set
        {
            if (SetProperty(ref _searchText, value))
            {
                FilteredContactsList = _contacts
                    .Where(x => x.Name.Contains(_searchText.Trim(), StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }
        }
    }
}