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

public partial class ContactsListViewModel : ViewModelBase,
    IRecipient<ContactAddedMessage>
{
    private readonly IContactsService _contactService;
    
    public ContactsListViewModel()
    {
        _contactService = App.Current.Services.GetService<IContactsService>()!;
        _searchText = "";
        _contacts = _contactService.GetContacts().OrderBy(x => x.Name).ToList();
        FilteredContactsList = _contacts;
        IsActive = true;
    }

    private List<Contact> _contacts;

    [ObservableProperty] 
    private List<Contact> _filteredContactsList;

    private Contact? _selectedContact;
    public Contact? SelectedContact
    {
        get => _selectedContact;
        set
        {
            if (SetProperty(ref _selectedContact, value))
            {
                Messenger.Send(new ContactSelectionMessage(_selectedContact));
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
                UpdateContactList();
            }
        }
    }
    
    private void UpdateContactList()
    {
        FilteredContactsList = _contacts
            .Where(x => x.Name.Contains(_searchText.Trim(), StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public void Receive(ContactAddedMessage message)
    {
        _contacts = _contactService.GetContacts().OrderBy(x => x.Name).ToList();
        UpdateContactList();
    }
}