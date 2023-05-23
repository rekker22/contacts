using System;
using System.Collections.Generic;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using Contacts.Core.Interfaces;
using Contacts.Core.Models;
using Contacts.Desktop.Messages;
using Microsoft.Extensions.DependencyInjection;

namespace Contacts.Desktop.ViewModels;

public partial class ContactsListViewModel : ViewModelBase
{
    public ContactsListViewModel()
    {
        var contactService = App.Current.Services.GetService<IContactsService>();
        _searchText = "";
        _contacts = contactService!.GetContacts().ToList();
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
                WeakReferenceMessenger.Default.Send(new ContactSelectionMessage(_selectedContact));
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